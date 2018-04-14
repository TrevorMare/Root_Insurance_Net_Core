using System;
using System.Collections.Generic;
using System.Text;
using GoogleDialogFlow.API.Core.Interfaces;
using Newtonsoft.Json;
using System.Linq;
using GoogleDialogFlow.API.Core.Helpers;

namespace GoogleDialogFlow.API.Core.Models
{
    public class DialogFlowInputFulfillment : IDialogFlowInputFulfillment
    {

        #region Properties
        [JsonProperty("speech")]
        public string Speech { get; set; }
        [JsonProperty("messages")]
        [JsonConverter(typeof(ConcreteListTypeConverter<IDialogFlowInputFulfillmentMessage, DialogFlowInputFulfillmentMessage>))]
        public List<IDialogFlowInputFulfillmentMessage> Messages { get; set; }
        #endregion
    }
}
