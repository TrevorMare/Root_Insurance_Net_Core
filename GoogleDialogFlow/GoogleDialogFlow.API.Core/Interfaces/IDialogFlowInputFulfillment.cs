using System;
using System.Collections.Generic;
using System.Text;

namespace GoogleDialogFlow.API.Core.Interfaces
{
    public interface IDialogFlowInputFulfillment
    {

        #region Properties
        string Speech { get; set; }
        List<IDialogFlowInputFulfillmentMessage> Messages { get; set; }
        #endregion

    }
}
