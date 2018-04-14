using System;
using System.Collections.Generic;
using System.Text;

namespace GoogleDialogFlow.API.Core.Interfaces
{
    public interface IDialogFlowInputStatus
    {

        #region Properties
        int Code { get; set; }
        string ErrorType { get; set; }
        bool WebhookTimedOut { get; set; }
        #endregion

    }
}
