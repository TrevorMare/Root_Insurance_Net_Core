using System;
using System.Collections.Generic;
using System.Text;
using GoogleDialogFlow.API.Core.Helpers;
using GoogleDialogFlow.API.Core.Interfaces;
using Newtonsoft.Json;

namespace GoogleDialogFlow.API.Core.Models
{
    public class DialogFlowOutputDataRichResponseItem : IDialogFlowOutputDataRichResponseItem
    {

        #region Properties
        [JsonProperty("simpleResponse")]
        [JsonConverter(typeof(ConcreteTypeConverter<DialogFlowOutputDataSimpleResponse>))]
        public IDialogFlowOutputDataSimpleResponse SimpleResponse { get; set; }
        #endregion

    }
}
