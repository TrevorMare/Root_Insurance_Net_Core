using System;
using System.Collections.Generic;
using System.Text;

namespace GoogleDialogFlow.API.Core.Interfaces
{
    public interface IDialogFlowOutputDataRichResponseItem
    {

        #region Properties
        IDialogFlowOutputDataSimpleResponse SimpleResponse { get; set; }
        #endregion


    }
}
