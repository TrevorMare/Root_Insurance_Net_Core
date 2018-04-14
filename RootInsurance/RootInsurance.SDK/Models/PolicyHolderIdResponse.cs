using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace RootInsurance.SDK.Models
{
    public class PolicyHolderIdResponse
    {

        #region Properties
        [JsonProperty("type")]
        public Common.E_IdentificationType IdentificationType { get; set; }
        [JsonProperty("number")]
        public string Number { get; set; }
        [JsonProperty("country")]
        public string CountryCode { get; set; }
        #endregion


    }
}
