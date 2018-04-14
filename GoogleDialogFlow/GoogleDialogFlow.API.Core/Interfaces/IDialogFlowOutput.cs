using System;
using System.Collections.Generic;
using System.Text;

namespace GoogleDialogFlow.API.Core.Interfaces
{
    public interface IDialogFlowOutput
    {

        #region Properties
        string Speech { get; set; }
        string DisplayText { get; set; }
        IDialogFlowOutputMessages Messages { get; set; }
        IDialogFlowOutputData Data { get; set; }
        List<IDialogFlowOutputContextOut> ContextOut { get; set; }
        string Source { get; set; }
        IDialogFlowOutputFollowupEvent FollowupEvent { get; set; }
        #endregion

    }
}
