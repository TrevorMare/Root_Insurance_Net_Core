using GoogleDialogFlow.API.Core.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace GoogleDialogFlow.API.Core.Models
{
    public class DialogFlowOutputDataSimpleResponse : IDialogFlowOutputDataSimpleResponse
    {

        #region Properties
        [JsonProperty("textToSpeech")]
        public string TextToSpeech { get; set; }
        #endregion

    }
}
