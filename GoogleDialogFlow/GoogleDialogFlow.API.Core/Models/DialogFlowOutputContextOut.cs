using GoogleDialogFlow.API.Core.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace GoogleDialogFlow.API.Core.Models
{
    public class DialogFlowOutputContextOut : IDialogFlowOutputContextOut
    {

        #region Properties
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("lifespan")]
        public int Lifespan { get; set; }
        [JsonProperty("parameters")]
        public Dictionary<string, object> Parameters { get; set; }
        #endregion

    }
}
