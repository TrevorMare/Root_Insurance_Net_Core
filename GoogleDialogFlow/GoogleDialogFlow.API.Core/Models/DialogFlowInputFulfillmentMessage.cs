using GoogleDialogFlow.API.Core.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace GoogleDialogFlow.API.Core.Models
{
    public class DialogFlowInputFulfillmentMessage : IDialogFlowInputFulfillmentMessage
    {
        #region Properties
        [JsonProperty("type")]
        public int Type { get; set; }
        [JsonProperty("speech")]
        public string Speech { get; set; }
        #endregion
    }
}
