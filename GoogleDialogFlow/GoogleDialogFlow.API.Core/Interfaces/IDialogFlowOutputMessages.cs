using System;
using System.Collections.Generic;
using System.Text;

namespace GoogleDialogFlow.API.Core.Interfaces
{
    public interface IDialogFlowOutputMessages
    {

        #region Properties
        int Type { get; set; }
        string Title { get; set; }
        string SubTitle { get; set; }
        string ImageUrl { get; set; }
        #endregion

    }
}
