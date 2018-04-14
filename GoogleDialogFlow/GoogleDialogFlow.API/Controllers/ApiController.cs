using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;

namespace GoogleDialogFlow.API.Controllers
{
    [Route("[controller]")]
    public class ApiController : Controller
    {

        #region Fields
        private readonly Data.Interfaces.IState _dbState;
        private readonly Interfaces.IAvailableActions _availableActions;
        #endregion

        #region ctor
        public ApiController(Data.Interfaces.IState dbState, Interfaces.IAvailableActions availableActions)
        {
            _dbState = dbState;
            _availableActions = availableActions;
        }
        #endregion

        #region Api Methods
        // POST api/values
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]Core.Models.DialogFlowInput value)
        {
            Core.Interfaces.IDialogFlowOutput response = new Core.Models.DialogFlowOutput() { Source = "https://7aaf2848.ngrok.io/api" };
            // Check for an action with the specified name
            string intentName = value?.Result?.Metadata?.IntentName; 
            if (!string.IsNullOrEmpty(intentName))
            {
                Interfaces.IDialogFlowAction dialogFlowAction = this._availableActions.DialogFlowActions.FirstOrDefault(o => o.IntentName.ToLower() == intentName.ToLower());
                if (dialogFlowAction != null)
                {
                    dialogFlowAction.DBState = this._dbState;
                    response = await dialogFlowAction.ExecuteAsync(value);
                }
            }
            return new JsonResult(response);
        }
        #endregion

    }
}
