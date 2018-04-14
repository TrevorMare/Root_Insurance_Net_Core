using System;
using System.Collections.Generic;
using System.Text;

namespace GoogleDialogFlow.API.Core.Interfaces
{
    public interface IDialogFlowOutputData 
    {

        #region Properties
        IDialogFlowOutputDataGoogle Google { get; set; }
        IDialogFlowOutputDataText Facebook { get; set; }
        IDialogFlowOutputDataText Slack { get; set; }
        #endregion

    }
}
