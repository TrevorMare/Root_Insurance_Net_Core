using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace RootInsurance.SDK.Models
{
    public class PolicyHolderResponse
    {

        #region Properties
        [JsonProperty("policyholder_id")]
        public string PolicyHolderId { get; set; }
        [JsonProperty("first_name")]
        public string FirstName { get; set; }
        [JsonProperty("last_name")]
        public string LastName { get; set; }
        [JsonProperty("id")]
        public PolicyHolderIdResponse id { get; set; }
        [JsonProperty("date_of_birth")]
        public string DateOfBirth { get; set; }
        [JsonProperty("email")]
        public string Email { get; set; }
        [JsonProperty("cellphone")]
        public string Cellphone { get; set; }
        [JsonProperty("created_at")]
        public DateTime CreatedAt { get; set; }
        [JsonProperty("app_data")]
        public object AppData { get; set; }
        [JsonProperty("policy_ids")]
        public object PolicyIds { get; set; }

        #endregion
    }
}





