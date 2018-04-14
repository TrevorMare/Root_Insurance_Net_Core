using GoogleDialogFlow.API.Core.Interfaces;
using GoogleDialogFlow.API.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using GoogleDialogFlow.API.Interfaces;

namespace GoogleDialogFlow.API.DialogFlowActions
{
    internal class SaveEmailAction : IDialogFlowAction
    {

        #region Properties
        public Data.Interfaces.IState DBState { get; set; }
        public string IntentName { get { return "01_A_Welcome_Intent"; } }
        #endregion

        #region Methods
        public async Task<IDialogFlowOutput> ExecuteAsync(IDialogFlowInput flowPostModel)
        {
            // Save the email with the session Id for later use
            var sessionId = flowPostModel.SessionId;
            var emailAddress = Helpers.DictionaryHelper.GetValue<string>(flowPostModel?.Result?.Parameters, "root_email");
            // Save the session and email to the store
            if (!string.IsNullOrEmpty(emailAddress))
            {
                // Get the user Id for the email
                var user = await DBState.GetUser(emailAddress);
                if (user == null)
                    user = await DBState.SaveUser(new Core.DataModels.User() { Email = emailAddress, CurrentSessionId = sessionId });
                else
                {
                    user.CurrentSessionId = sessionId;
                    user = await DBState.SaveUser(new Core.DataModels.User() { Email = emailAddress, CurrentSessionId = sessionId });
                }
                // Insert the session state if it does not exist
                await DBState.SaveUserSession(sessionId, emailAddress);
                // Save the session state


            }
            var response = new DialogFlowOutput();
            return response;
        }

        #endregion

    }
}
