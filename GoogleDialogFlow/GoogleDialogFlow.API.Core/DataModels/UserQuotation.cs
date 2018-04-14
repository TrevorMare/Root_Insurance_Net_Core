using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace GoogleDialogFlow.API.Core.DataModels
{
    public class UserQuotation
    {

        #region Properties
        [JsonProperty("session_id", NullValueHandling = NullValueHandling.Ignore)]
        public string SessionId { get; set; }
        [JsonProperty("time_stamp", NullValueHandling = NullValueHandling.Ignore)]
        public DateTime? TimeStamp { get; set; }
        [JsonProperty("user_quotes", NullValueHandling = NullValueHandling.Ignore)]
        public object UserQuotes { get; set; }
        #endregion
    }
}
