using GoogleDialogFlow.API.Core.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace GoogleDialogFlow.API.Core.Models
{
    public class DialogFlowOutputDataText : IDialogFlowOutputDataText
    {

        #region Properties
        [JsonProperty("text")]
        public string Text { get; set; }
        #endregion

    }
}
