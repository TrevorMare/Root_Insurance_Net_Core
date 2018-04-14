using GoogleDialogFlow.API.Core.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace GoogleDialogFlow.API.Core.Models
{
    public class DialogFlowOutputMessages : IDialogFlowOutputMessages
    {

        #region Properties
        [JsonProperty("type")]
        public int Type { get; set; }
        [JsonProperty("title")]
        public string Title { get; set; }
        [JsonProperty("subtitle")]
        public string SubTitle { get; set; }
        [JsonProperty("imageUrl")]
        public string ImageUrl { get; set; }
        #endregion

    }
}
