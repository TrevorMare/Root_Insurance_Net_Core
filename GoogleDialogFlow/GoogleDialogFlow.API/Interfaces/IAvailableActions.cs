using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoogleDialogFlow.API.Interfaces
{
    public interface IAvailableActions 
    {
        #region Properties
        List<IDialogFlowAction> DialogFlowActions { get; set; }
        #endregion

        #region Methods
        void LoadAvailableActions();
        #endregion
    }
}
