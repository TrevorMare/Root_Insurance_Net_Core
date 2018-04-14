using GoogleDialogFlow.API.Core.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace GoogleDialogFlow.API.Core.Models
{
    public class DialogFlowInputContext : IDialogFlowInputContext
    {

        #region Properties
        [JsonProperty("name")]
        public string name { get; set; }
        [JsonProperty("parameters")]
        public Dictionary<string, object> Parameters { get; set; } = new Dictionary<string, object>();
        [JsonProperty("lifespan")]
        public int Lifespan { get; set; }
        #endregion

    }
}
