using GoogleDialogFlow.API.Core.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace GoogleDialogFlow.API.Core.DataModels
{
    public class UserSessionState : DataModelBase
    {

        #region Properties
        [JsonProperty("session_id", NullValueHandling = NullValueHandling.Ignore)]
        public string SessionId { get; set; }
        [JsonProperty("sequence", NullValueHandling = NullValueHandling.Ignore)]
        public int? Sequence { get; set; }
        [JsonProperty("time_stamp", NullValueHandling = NullValueHandling.Ignore)]
        public DateTime? TimeStamp { get; set; }
        [JsonProperty("state", NullValueHandling = NullValueHandling.Ignore)]
        public IDialogFlowInput State { get; set; }
        #endregion

    }
}
