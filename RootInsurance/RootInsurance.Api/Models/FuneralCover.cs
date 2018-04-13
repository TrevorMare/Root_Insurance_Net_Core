using System;
using System.Collections.Generic;
using System.Text;

namespace RootInsurance.Api.Models
{
    public class FuneralCoverGetQuote
    {

        #region Properties
        /// <summary>
        /// The amount to cover in cents
        /// </summary>
        public int CoverAmount { get; set; }
        /// <summary>
        /// Should a spouse also be covered
        /// </summary>
        public bool HasSpouse { get; set; }
        /// <summary>
        /// Number of children to include in the policy. Should be between 0 and 8, inclusive
        /// </summary>
        public int NumberOfChildren { get; set; }
        /// <summary>
        /// Ages of extended family members to cover
        /// </summary>
        public int[] ExtendedFamilyAges { get; set; }
        #endregion

    }
}
