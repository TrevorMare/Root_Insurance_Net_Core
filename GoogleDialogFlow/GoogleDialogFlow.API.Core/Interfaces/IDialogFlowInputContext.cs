using System;
using System.Collections.Generic;
using System.Text;

namespace GoogleDialogFlow.API.Core.Interfaces
{
    public interface IDialogFlowInputContext
    {
        #region Properties
        string name { get; set; }
        Dictionary<string, object> Parameters { get; set; }
        int Lifespan { get; set; }
        #endregion
    }
}
