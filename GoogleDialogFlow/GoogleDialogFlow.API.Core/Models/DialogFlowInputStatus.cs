using GoogleDialogFlow.API.Core.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace GoogleDialogFlow.API.Core.Models
{
    public class DialogFlowInputStatus : IDialogFlowInputStatus
    {

        #region Properties
        [JsonProperty("code")]
        public int Code { get; set; }
        [JsonProperty("errorType")]
        public string ErrorType { get; set; }
        [JsonProperty("webhookTimedOut")]
        public bool WebhookTimedOut { get; set; }
        #endregion

    }
}
