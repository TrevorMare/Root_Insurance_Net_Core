using System;
using System.Collections.Generic;
using System.Text;
using GoogleDialogFlow.API.Core.Interfaces;
using Newtonsoft.Json;
using System.Linq;
using GoogleDialogFlow.API.Core.Helpers;

namespace GoogleDialogFlow.API.Core.Models
{
    public class DialogFlowInputResult : IDialogFlowInputResult
    {

        #region Properties
        [JsonProperty("source")]
        public string Source { get; set; }
        [JsonProperty("resolvedQuery")]
        public string ResolvedQuery { get; set; }
        [JsonProperty("speech")]
        public string Speech { get; set; }
        [JsonProperty("action")]
        public string Action { get; set; }
        [JsonProperty("actionIncomplete")]
        public bool ActionIncomplete { get; set; }
        [JsonProperty("parameters")]
        public Dictionary<string, object> Parameters { get; set; }
        [JsonProperty("contexts")]
        [JsonConverter(typeof(ConcreteListTypeConverter<IDialogFlowInputContext, DialogFlowInputContext>))]
        public List<IDialogFlowInputContext> Contexts { get; set; }
        [JsonProperty("metadata")]
        [JsonConverter(typeof(ConcreteTypeConverter<DialogFlowInputMetadata>))]
        public IDialogFlowInputMetadata Metadata { get; set; }
        [JsonProperty("fulfillment")]
        [JsonConverter(typeof(ConcreteTypeConverter<DialogFlowInputFulfillment>))]
        public IDialogFlowInputFulfillment Fulfillment { get; set; }
        [JsonProperty("score")]
        public float Score { get; set; }
        #endregion

    }
}
