using System;
using System.Collections.Generic;
using System.Text;

namespace GoogleDialogFlow.API.Core.Interfaces
{
    public interface IDialogFlowOutputDataRichResponse
    {

        #region Properties
        List<IDialogFlowOutputDataRichResponseItem> Items { get; set; }
        #endregion

    }
}
