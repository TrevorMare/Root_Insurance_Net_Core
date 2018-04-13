using System;
using System.Collections.Generic;
using System.Text;

namespace RootInsurance.Api.Models
{
    public class PolicyHolderCreate
    {

        #region Properties
        /// <summary>
        /// identification number of the policy holder
        /// </summary>
        public string Id { get; set; }
        /// <summary>
        /// A value indicating if it is an ID document or Passport
        /// </summary>
        public Common.E_IdentificationType IdentificationType { get; set; }
        /// <summary>
        /// ISO Code for the identity document
        /// </summary>
        public string IdCountryIso { get; set; }
        /// <summary>
        /// The policyholder's date of birth in the format YYYYMMDD. This field may be omitted if the policyholder's id type is id.
        /// </summary>
        public string DateOfBirth { get; set; }
        /// <summary>
        /// Policyholder's legal first name
        /// </summary>
        public string FirstName { get; set; }
        /// <summary>
        /// Policyholder's legal last name
        /// </summary>
        public string LastName { get; set; }
        /// <summary>
        /// Policyholder's contact email address
        /// </summary>
        public string Email { get; set; }
        /// <summary>
        /// Cellphone number 
        /// </summary>
        public string CellPhone { get; set; }
        /// <summary>
        /// ISO Code for cellphone number
        /// </summary>
        public string CellPhoneIso { get; set; }
        /// <summary>
        /// Additional data to be stored on the entity
        /// </summary>
        public object AppData { get; set; }
        #endregion

    }
}
