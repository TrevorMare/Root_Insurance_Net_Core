using System;
using System.Collections.Generic;
using System.Text;

namespace RootInsurance.Api.Models
{
    public class PolicyHolderUpdate
    {

        #region Properties
        /// <summary>
        /// The unique Id of the policy holder as returned by the Root Insurance Api
        /// </summary>
        public string PolicyHolderId { get; set; }
        /// <summary>
        /// Optional email address
        /// </summary>
        public string Email { get; set; }
        /// <summary>
        /// Optional CellPhone number
        /// </summary>
        public string CellPhone { get; set; }
        /// <summary>
        /// Optional CellPhone Number Country ISO code
        /// </summary>
        public string CellPhoneCountry { get; set; }
        /// <summary>
        /// Optional App Data to be saved on the entity
        /// </summary>
        public object AppData { get; set; }
        #endregion

    }
}
