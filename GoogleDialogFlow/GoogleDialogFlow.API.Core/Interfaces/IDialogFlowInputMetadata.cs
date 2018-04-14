using System;
using System.Collections.Generic;
using System.Text;

namespace GoogleDialogFlow.API.Core.Interfaces
{
    public interface IDialogFlowInputMetadata
    {

        #region Properties
        string IntentId { get; set; }
        string WebhookUsed { get; set; }
        string WebhookForSlotFillingUsed { get; set; }
        string IntentName { get; set; }
        #endregion

    }
}
