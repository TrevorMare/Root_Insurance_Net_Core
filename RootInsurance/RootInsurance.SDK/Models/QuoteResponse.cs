using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace RootInsurance.SDK.Models
{
    public class QuoteResponse
    {

        #region Properties
        [JsonProperty("package_name")]
        public string PackageName { get; set; }
        [JsonProperty("sum_assured")]
        public int SumAssured { get; set; }
        [JsonProperty("base_premium")]
        public int BasePremium { get; set; }
        [JsonProperty("suggested_premium")]
        public int SuggestedPremium { get; set; }
        [JsonProperty("created_at")]
        public DateTime CreatedAt { get; set; }
        [JsonProperty("quote_package_id")]
        public string QuotePackageId { get; set; }
        [JsonProperty("module")]
        public QuoteModuleResponse Module { get; set; }
        #endregion
    }
}
