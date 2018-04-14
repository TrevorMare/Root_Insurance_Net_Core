using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoogleDialogFlow.API.Interfaces
{
    public interface IDialogFlowAction
    {

        #region Properties
        Data.Interfaces.IState DBState { get; set; }
        /// <summary>
        /// Gets the intent name for the action
        /// </summary>
        string IntentName { get; }
        #endregion

        #region Methods
        Task<GoogleDialogFlow.API.Core.Interfaces.IDialogFlowOutput> ExecuteAsync(GoogleDialogFlow.API.Core.Interfaces.IDialogFlowInput flowInput);
        #endregion

    }
}
