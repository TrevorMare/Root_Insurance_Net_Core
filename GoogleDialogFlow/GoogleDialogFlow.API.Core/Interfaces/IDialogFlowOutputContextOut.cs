using System;
using System.Collections.Generic;
using System.Text;

namespace GoogleDialogFlow.API.Core.Interfaces
{
    public interface IDialogFlowOutputContextOut
    {

        #region Properties
        string Name { get; set; }
        int Lifespan { get; set; }
        Dictionary<string, object> Parameters { get; set; }
        #endregion

    }
}
