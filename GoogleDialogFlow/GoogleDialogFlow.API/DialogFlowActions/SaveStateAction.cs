
using GoogleDialogFlow.API.Core.Interfaces;
using GoogleDialogFlow.API.Core.Models;
using GoogleDialogFlow.API.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoogleDialogFlow.API.DialogFlowActions
{
    internal class SaveStateAction : IDialogFlowAction
    {

        #region Properties
        public Data.Interfaces.IState DBState { get; set; }
        public string IntentName { get { return "97_Save_State"; } }
        #endregion

        #region Methods
        public async Task<IDialogFlowOutput> ExecuteAsync(IDialogFlowInput flowPostModel)
        {
            // Save the email with the session Id for later use
            var sessionId = flowPostModel.SessionId;
            // Save the session state
            await DBState.SaveSessionState(sessionId, flowPostModel);
            // Save the session and email to the store
            var response = new DialogFlowOutput();
            // Return a blank response
            return response;
        }
        #endregion

    }
}
