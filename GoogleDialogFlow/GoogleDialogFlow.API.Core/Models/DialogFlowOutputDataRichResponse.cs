using System;
using System.Collections.Generic;
using System.Text;
using GoogleDialogFlow.API.Core.Interfaces;
using Newtonsoft.Json;
using System.Linq;
using GoogleDialogFlow.API.Core.Helpers;

namespace GoogleDialogFlow.API.Core.Models
{
    public class DialogFlowOutputDataRichResponse : IDialogFlowOutputDataRichResponse
    {


        #region Properties
        [JsonProperty("items")]
        [JsonConverter(typeof(ConcreteListTypeConverter<IDialogFlowOutputDataRichResponseItem, DialogFlowOutputDataRichResponseItem>))]
        public List<IDialogFlowOutputDataRichResponseItem> Items { get; set; }
        #endregion

    }
}
