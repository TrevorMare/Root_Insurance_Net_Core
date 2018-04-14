using System;
using System.Collections.Generic;
using System.Text;

namespace GoogleDialogFlow.API.Core.Interfaces
{
    public interface IDialogFlowInput
    {

        #region Properties
        string Id { get; set; }
        DateTime TimeStamp { get; set; }
        string Language { get; set; }
        IDialogFlowInputResult Result { get; set; }
        IDialogFlowInputStatus Status { get; set; }
        string SessionId { get; set; }
        #endregion

    }
}
