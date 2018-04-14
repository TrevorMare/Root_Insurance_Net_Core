using System;
using System.Collections.Generic;
using System.Text;

namespace GoogleDialogFlow.API.Core.Interfaces
{
    public interface IDialogFlowInputResult
    {

        #region Properties
        string Source { get; set; }
        string ResolvedQuery { get; set; }
        string Speech { get; set; }
        string Action { get; set; }
        bool ActionIncomplete { get; set; }
        Dictionary<string, object> Parameters { get; set; }
        List<IDialogFlowInputContext> Contexts { get; set; }
        IDialogFlowInputMetadata Metadata { get; set; }
        IDialogFlowInputFulfillment Fulfillment { get; set; }
        float Score { get; set; }
        #endregion

    }
}
