using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GoogleDialogFlow.API.Data.Interfaces
{
    public interface IState
    {

        #region Methods
        void SeedDatabase();

        Task<Core.DataModels.User> GetUser(string email);
        Task<Core.DataModels.User> SaveUser(Core.DataModels.User model);
        Task<string> GetUserId(string email);
        Task<Core.DataModels.UserSession> SaveUserSession(string userId, string sessionId);
        Task<Core.DataModels.UserSession> GetUserSession(string userId, string sessionId);
        Task<Core.DataModels.UserSession> GetUserSession(string sessionId);
        Task<bool> SaveSessionState(string sessionId, Core.Interfaces.IDialogFlowInput dialogFlowInput);
        Task<Core.Interfaces.IDialogFlowInput> GetLastUserSessionState(string sessionId);
        Task SaveUserQuotation(string sessionId, object quoteResponse);



        Task<bool> ClearPreviousQuotes();
        Task<bool> CreatePolicyHolder(string email, Core.Interfaces.IDialogFlowInput dialogFlowInput);
        Task<bool> DeleteQuotation(Core.Interfaces.IDialogFlowInput dialogFlowInput);
        #endregion

    }
}
