using System;
using System.Collections.Generic;
using System.Text;
using GoogleDialogFlow.API.Core.Helpers;
using GoogleDialogFlow.API.Core.Interfaces;
using Newtonsoft.Json;

namespace GoogleDialogFlow.API.Core.Models
{
    public class DialogFlowOutputData : IDialogFlowOutputData
    {

  
        #region Properties
        [JsonProperty("Google")]
        [JsonConverter(typeof(ConcreteTypeConverter<DialogFlowOutputDataGoogle>))]
        public IDialogFlowOutputDataGoogle Google { get; set; }
        [JsonProperty("Facebook")]
        [JsonConverter(typeof(ConcreteTypeConverter<DialogFlowOutputDataText>))]
        public IDialogFlowOutputDataText Facebook { get; set; }
        [JsonProperty("Slack")]
        [JsonConverter(typeof(ConcreteTypeConverter<DialogFlowOutputDataText>))]
        public IDialogFlowOutputDataText Slack { get; set; }
        #endregion

    }
}
