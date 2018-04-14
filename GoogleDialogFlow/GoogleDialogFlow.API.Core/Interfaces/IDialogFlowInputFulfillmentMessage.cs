using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace GoogleDialogFlow.API.Core.Interfaces
{
    public interface IDialogFlowInputFulfillmentMessage
    {

        #region Properties
        int Type { get; set; }
        string Speech { get; set; }
        #endregion

    }
}
