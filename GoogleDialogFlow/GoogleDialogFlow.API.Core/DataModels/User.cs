using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace GoogleDialogFlow.API.Core.DataModels
{
    public class User : DataModelBase
    {

        #region Properties
        [JsonProperty("email", NullValueHandling = NullValueHandling.Ignore)]
        public string Email { get; set; }
        [JsonProperty("current_session", NullValueHandling = NullValueHandling.Ignore)]
        public string CurrentSessionId { get; set; }
        [JsonProperty("policy_number", NullValueHandling = NullValueHandling.Ignore)]
        public string PolicyNumber { get; set; }
        [JsonProperty("id_number", NullValueHandling = NullValueHandling.Ignore)]
        public string IdNumber { get; set; }
        #endregion

    }
}
