using GoogleDialogFlow.API.Core.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace GoogleDialogFlow.API.Core.Models
{
    public class DialogFlowInputMetadata : IDialogFlowInputMetadata
    {

        #region Properties
        [JsonProperty("intentId")]
        public string IntentId { get; set; }
        [JsonProperty("webhookUsed")]
        public string WebhookUsed { get; set; }
        [JsonProperty("webhookForSlotFillingUsed")]
        public string WebhookForSlotFillingUsed { get; set; }
        [JsonProperty("intentName")]
        public string IntentName { get; set; }
        #endregion

    }
}
