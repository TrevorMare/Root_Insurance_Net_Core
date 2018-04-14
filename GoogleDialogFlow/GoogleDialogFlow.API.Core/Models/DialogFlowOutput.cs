using GoogleDialogFlow.API.Core.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using GoogleDialogFlow.API.Core.Helpers;

namespace GoogleDialogFlow.API.Core.Models
{
    public class DialogFlowOutput : IDialogFlowOutput
    {

        #region Properties
        [JsonProperty("speech")]
        public string Speech { get; set; }
        [JsonProperty("displayText")]
        public string DisplayText { get; set; }
        [JsonProperty("messages")]
        [JsonConverter(typeof(ConcreteTypeConverter<DialogFlowOutputMessages>))]
        public IDialogFlowOutputMessages Messages { get; set; }
        [JsonProperty("data")]
        [JsonConverter(typeof(ConcreteTypeConverter<DialogFlowOutputData>))]
        public IDialogFlowOutputData Data { get; set; }
        [JsonProperty("contextOut")]
        [JsonConverter(typeof(ConcreteListTypeConverter<IDialogFlowOutputContextOut, DialogFlowOutputContextOut>))]
        public List<IDialogFlowOutputContextOut> ContextOut { get; set; }
        [JsonProperty("source")]
        public string Source { get; set; }
        [JsonProperty("followupEvent")]
        [JsonConverter(typeof(ConcreteTypeConverter<DialogFlowOutputFollowupEvent>))]
        public IDialogFlowOutputFollowupEvent FollowupEvent { get; set; }
        #endregion
    }
}
