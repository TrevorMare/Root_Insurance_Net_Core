using System;
using System.Collections.Generic;
using System.Text;

namespace GoogleDialogFlow.API.Core.Interfaces
{
    public interface IDialogFlowOutputFollowupEvent
    {

        #region Properties
        string Name { get; set; }
        Dictionary<string, object> Parameters { get; set; }
        #endregion

    }
}
