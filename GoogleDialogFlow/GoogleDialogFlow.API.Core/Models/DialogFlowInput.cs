using System;
using System.Collections.Generic;
using System.Text;
using GoogleDialogFlow.API.Core.Helpers;
using GoogleDialogFlow.API.Core.Interfaces;
using Newtonsoft.Json;

namespace GoogleDialogFlow.API.Core.Models
{
    public class DialogFlowInput :IDialogFlowInput
    {

        #region Properties
        [JsonProperty("id")]
        public string Id { get; set; }
        [JsonProperty("timestamp")]
        public DateTime TimeStamp { get; set; }
        [JsonProperty("lang")]
        public string Language { get; set; }
        [JsonProperty("result")]
        [JsonConverter(typeof(ConcreteTypeConverter<DialogFlowInputResult>))]
        public IDialogFlowInputResult Result { get; set; }
        [JsonProperty("status")]
        [JsonConverter(typeof(ConcreteTypeConverter<DialogFlowInputStatus>))]
        public IDialogFlowInputStatus Status { get; set; }
        [JsonProperty("sessionId")]
        public string SessionId { get; set; }
        #endregion

    }
}
