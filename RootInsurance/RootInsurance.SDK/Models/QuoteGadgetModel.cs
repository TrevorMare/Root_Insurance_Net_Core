using System;
using System.Collections.Generic;
using System.Text;

using Newtonsoft.Json;

namespace RootInsurance.SDK.Models
{
    public class QuoteGadgetModel
    {

        #region Properties
        [JsonProperty("make")]
        public string Make { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("value")]
        public long Value { get; set; }
        #endregion


    }
}
