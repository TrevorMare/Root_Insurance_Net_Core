using System;
using System.Collections.Generic;
using System.Text;
using GoogleDialogFlow.API.Core.Helpers;
using GoogleDialogFlow.API.Core.Interfaces;
using Newtonsoft.Json;

namespace GoogleDialogFlow.API.Core.Models
{
    public class DialogFlowOutputDataGoogle : IDialogFlowOutputDataGoogle
    {

        #region Properties
        [JsonProperty("expectUserResponse")]
        public bool ExpectUserResponse { get; set; }
        [JsonProperty("richResponse")]
        [JsonConverter(typeof(ConcreteTypeConverter<DialogFlowOutputDataRichResponse>))]
        public IDialogFlowOutputDataRichResponse RichResponse { get; set; }
        #endregion
    }
}
