using System;
using System.Collections.Generic;
using System.Text;

namespace GoogleDialogFlow.API.Core.Interfaces
{
    public interface IDialogFlowOutputDataGoogle
    {
        #region Properties
        bool ExpectUserResponse { get; set; }
        IDialogFlowOutputDataRichResponse RichResponse { get; set; }
        #endregion
    }
}
