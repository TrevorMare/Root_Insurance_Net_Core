using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using GoogleDialogFlow.API.Core.Interfaces;
using RethinkDb.Driver;
using RethinkDb.Driver.Ast;
using RethinkDb.Driver.Net;
using System.Linq;

namespace GoogleDialogFlow.API.Data.RethinkDBData
{
    public class RethinkDBState : Interfaces.IState
    {

        #region Fields
        private string _dbName = "DialogFlowDB";
        private string _rethinkHostUrl = "";
        private int _rethinkHostPort = 0;
        #endregion

        #region Static Fields
        internal static RethinkDB rethinkDB = RethinkDB.R;
        internal static Connection connection = null;
        #endregion

        #region ctor
        public RethinkDBState(string hostName = "127.0.0.1", int port = RethinkDBConstants.DefaultPort)
        {
            this._rethinkHostUrl = hostName;
            this._rethinkHostPort = port;
            if (connection == null)
            {
                connection = rethinkDB
                       .Connection()
                       .Hostname(hostName)
                       .Port(port)
                       .Timeout(60)
                       .Connect();
            }
        }
        #endregion

        #region DB Structure
        public void SeedDatabase()
        {
            // Create the database if it does not exist
            List<string> dbList = rethinkDB.DbList().Run<List<string>>(connection);
            if (dbList.Contains(this._dbName))
            {
                rethinkDB.DbDrop(this._dbName).Run(connection);
                rethinkDB.DbCreate(this._dbName).Run(connection);
            }
            else if (!dbList.Contains(this._dbName))
            {
                rethinkDB.DbCreate(this._dbName).Run(connection);
            }
            // Load the tables from the database
            List<string> tableList = rethinkDB.Db(this._dbName).TableList().Run<List<string>>(connection);
            List<string> createTables = new List<string>() { "Users", "UserSession", "SessionState", "PolicyHolders", "UserQuotation" };
            // Create the tables if they do not exist
            foreach (var tableName in createTables)
            {
                // Check if the table exists in the database
                if (!tableList.Contains(tableName))
                {
                    rethinkDB.Db(this._dbName).TableCreate(tableName).Run(connection);
                }
            }
        }
        #endregion

        #region Methods
        public async Task<Core.DataModels.User> GetUser(string email)
        {
            var users = await rethinkDB.Db(this._dbName)
               .Table("Users")
               .Filter(reql => this.BuildDynamicFilter(reql, new Dictionary<string, object>() { { "email", email } }))
               .RunAtomAsync<List<Core.DataModels.User>>(connection);
            if (users != null && users.Count != 0)
                return users[0];
            return null;
        }
        public async Task<Core.DataModels.User> SaveUser(Core.DataModels.User model)
        {
            if (string.IsNullOrEmpty(model.Id))
                await rethinkDB.Db(this._dbName).Table("Users").Insert(model).RunAsync(connection);
            else
                await rethinkDB.Db(this._dbName).Table("Users").Update(model).RunAsync(connection);
            return await GetUser(model.Email);
        }
        public async Task<string> GetUserId(string email)
        {
            var model = await this.GetUser(email);
            return model?.Id;
        }
        public async Task<Core.DataModels.UserSession> SaveUserSession(string userId, string sessionId)
        {
            var userSessions = await rethinkDB.Db(this._dbName)
              .Table("UserSession")
              .Filter(reql => this.BuildDynamicFilter(reql, new Dictionary<string, object>() { { "user_id", userId }, { "session_id", sessionId } }))
              .RunAtomAsync<List<Core.DataModels.UserSession>>(connection);

            if (userSessions != null && userSessions.Count != 0)
            {
                Core.DataModels.UserSession userSession = userSessions[0];
                userSession.TimeStamp = DateTime.Now;
                userSession.Sequence += 1;
                await rethinkDB.Db(this._dbName).Table("UserSession").Update(userSession).RunAsync(connection);
                return userSession;
            }
            else
            {
                Core.DataModels.UserSession userSession = new Core.DataModels.UserSession()
                {
                    Sequence = 1,
                    SessionId = sessionId,
                    TimeStamp = DateTime.Now,
                    UserId = userId
                };
                await rethinkDB.Db(this._dbName).Table("UserSession").Insert(userSession).RunAsync(connection);
                return await this.GetUserSession(userId, sessionId);
            }
        }
        public async Task<Core.DataModels.UserSession> GetUserSession(string userId, string sessionId)
        {
            var userSessions = await rethinkDB.Db(this._dbName)
              .Table("UserSession")
              .Filter(reql => this.BuildDynamicFilter(reql, new Dictionary<string, object>() { { "user_id", userId }, { "session_id", sessionId } }))
              .RunAtomAsync<List<Core.DataModels.UserSession>>(connection);
            if (userSessions != null && userSessions.Count != 0)
                return userSessions[0];
            return null;
        }
        public async Task<Core.DataModels.UserSession> GetUserSession(string sessionId)
        {
            var userSessions = await rethinkDB.Db(this._dbName)
              .Table("UserSession")
              .Filter(reql => this.BuildDynamicFilter(reql, new Dictionary<string, object>() { { "session_id", sessionId } }))
              .RunAtomAsync<List<Core.DataModels.UserSession>>(connection);
            if (userSessions != null && userSessions.Count != 0)
                return userSessions[0];
            return null;
        }
        public async Task<bool> SaveSessionState(string sessionId, IDialogFlowInput dialogFlowInput)
        {
            var userSession = await this.GetUserSession(sessionId);
            if (userSession != null)
            {
                var sessionState = new Core.DataModels.UserSessionState()
                {
                    Sequence = userSession.Sequence,
                    SessionId = sessionId,
                    TimeStamp = DateTime.Now,
                    State = dialogFlowInput
                };
                await rethinkDB.Db(this._dbName).Table("SessionState").Insert(sessionState).RunAsync(connection);
                userSession.Sequence += 1;
                await rethinkDB.Db(this._dbName).Table("UserSession").Update(userSession).RunAsync(connection);
            }
            return true;
        }
        public async Task<IDialogFlowInput> GetLastUserSessionState(string sessionId)
        {
            var userSessionStates = await rethinkDB.Db(this._dbName)
              .Table("SessionState")
              .Filter(reql => this.BuildDynamicFilter(reql, new Dictionary<string, object>() { { "session_id", sessionId } }))
              .RunAtomAsync<List<Core.DataModels.UserSessionState>>(connection);

            if (userSessionStates != null && userSessionStates.Count != 0)
            {
                var userState = userSessionStates.OrderByDescending(o => o.Sequence).FirstOrDefault();
                return userState.State;
            }
            return null;
        }
        public async Task SaveUserQuotation(string sessionId, object quoteResponse)
        {
            var userQuotation = new Core.DataModels.UserQuotation()
            {
                SessionId = sessionId,
                TimeStamp = DateTime.Now,
                UserQuotes = quoteResponse
            };
            await rethinkDB.Db(this._dbName).Table("UserQuotation").Insert(userQuotation).RunAsync(connection);
        }

        public Task<bool> ClearPreviousQuotes()
        {
            throw new NotImplementedException();
        }

        public Task<bool> CreatePolicyHolder(string email, IDialogFlowInput dialogFlowInput)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteQuotation(IDialogFlowInput dialogFlowInput)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region Helper Methods
        private ReqlExpr BuildDynamicFilter(ReqlExpr expr, Dictionary<string, object> parameters)
        {
            var statement = rethinkDB.And();
            if (parameters != null && parameters.Keys.Count > 0)
            {
                foreach (var key in parameters.Keys)
                {
                    statement = statement.And(expr[key].Eq(parameters[key]));
                }
            }
            return statement;
        }
        #endregion
    }
}
