using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace GoogleDialogFlow.API.Core.DataModels
{
    public class UserSession : DataModelBase
    {

        #region Properties

        [JsonProperty("user_id", NullValueHandling = NullValueHandling.Ignore)]
        public string UserId { get; set; }
        [JsonProperty("session_id", NullValueHandling = NullValueHandling.Ignore)]
        public string SessionId { get; set; }
        [JsonProperty("time_stamp", NullValueHandling = NullValueHandling.Ignore)]
        public DateTime? TimeStamp { get; set; }
        [JsonProperty("sequence", NullValueHandling = NullValueHandling.Ignore)]
        public int? Sequence { get; set; }
        #endregion

    }
}
