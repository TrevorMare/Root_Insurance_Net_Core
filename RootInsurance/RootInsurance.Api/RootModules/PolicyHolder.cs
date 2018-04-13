using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RootInsurance.Api.RootModules
{
    public class PolicyHolder
    {

        /// <summary>
        /// Creates a new policy holder
        /// </summary>
        /// <param name="id">identification number</param>
        /// <param name="identificationType">A value indicating if it is an ID document or Passport</param>
        /// <param name="idCountryIso">ISO Code for the identity document</param>
        /// <param name="date_of_birth">The policyholder's date of birth in the format YYYYMMDD. This field may be omitted if the policyholder's id type is id.</param>
        /// <param name="first_name">Policyholder's legal first name.</param>
        /// <param name="lastName">Policyholder's legal last name.</param>
        /// <param name="email">Policyholder's contact email address.</param>
        /// <param name="cellPhone"> Cellphone number </param>
        /// <param name="cellIdIso">ISO Code for cellphone number</param>
        /// <param name="appData">Additional data to be stored on the entity</param>
        public async Task<Models.PolicyHolderResponse> CreatePolicyHolder(string id, Common.E_IdentificationType identificationType, string idCountryIso, string dateOfBirth, string firstName, string lastName, string email, string cellPhone, string cellIdIso, object appData)
        {
            if (string.IsNullOrEmpty(id))
                throw new Common.ValidationException("Id is required");
            if (identificationType == Common.E_IdentificationType.passport && string.IsNullOrEmpty(dateOfBirth))
                throw new Common.ValidationException("Date of birth is required when the identification type is passport");
            if (string.IsNullOrEmpty(idCountryIso))
                throw new Common.ValidationException("Please provide the country ISO code for the identification document");
            if (string.IsNullOrEmpty(firstName))
                throw new Common.ValidationException("First name cannot be blank");
            if (string.IsNullOrEmpty(lastName))
                throw new Common.ValidationException("Last name cannot be blank");
            if (!string.IsNullOrEmpty(cellPhone) && string.IsNullOrEmpty(cellIdIso))
                throw new Common.ValidationException("Please provide the country ISO code for the cellphone number");
            return await ApiManager.WebHelper.CallWebApi<Models.PolicyHolderResponse>("policyholders", new System.Net.Http.HttpMethod("POST"), 
                new
                {
                    id = new { type = identificationType.ToString(), number = id, country = idCountryIso.ToUpper() },
                    date_of_birth = dateOfBirth,
                    first_name = firstName,
                    last_name = lastName,
                    email = email,
                    cellphone = (string.IsNullOrEmpty(cellPhone) ? null : new { number = cellPhone, country = cellIdIso }),
                    app_data = appData
                });
        }

        /// <summary>
        /// Gets a list of policy holders
        /// </summary>
        /// <param name="id">An optional parameter to find by Id number/passport number</param>
        /// <returns></returns>
        public async Task<List<Models.PolicyHolderResponse>> GetPolicyHolders(string id = null)
        {
            string url = "policyholders" + (string.IsNullOrEmpty(id) ? "" : $"?id_number={id}");
            return await ApiManager.WebHelper.CallWebApi<List<Models.PolicyHolderResponse>>(url, new System.Net.Http.HttpMethod("GET"));
        }
        /// <summary>
        /// Finds a policy holder by the unique Id
        /// </summary>
        /// <param name="policyholder_id"></param>
        /// <returns></returns>
        public async Task<Models.PolicyHolderResponse> GetPolicyHolderByUID(string policyholder_id)
        {
            string url = "policyholders" + (string.IsNullOrEmpty(policyholder_id) ? "" : $"?policyholder_id={policyholder_id}");
            return await ApiManager.WebHelper.CallWebApi<Models.PolicyHolderResponse>(url, new System.Net.Http.HttpMethod("GET"));
        }
        /// <summary>
        /// Updates an existing policy holder's information
        /// </summary>
        /// <param name="policyholder_id">The unique Id of the policy holder</param>
        /// <param name="email">Optional email</param>
        /// <param name="cellPhone">Optional CellPhone</param>
        /// <param name="cellPhoneCountry">The ISO Code for the country</param>
        /// <param name="appData">The additional details to be stored on the policy holder</param>
        /// <returns></returns>
        public async Task<Models.PolicyHolderResponse> UpdatePolicyHolderByUID(string policyholder_id, string email, string cellPhone, string cellPhoneCountry, object appData)
        {
            if (!string.IsNullOrEmpty(cellPhone) && string.IsNullOrEmpty(cellPhoneCountry))
                throw new Common.ValidationException("Please provide the country ISO code for the cellphone number");
            string url = $"policyholders/{policyholder_id}";
            return await ApiManager.WebHelper.CallWebApi<Models.PolicyHolderResponse>(url, new System.Net.Http.HttpMethod("PATCH"),
                new
                {
                    email = email,
                    cellphone = (string.IsNullOrEmpty(cellPhone) ? null : new { number = cellPhone, country = cellPhoneCountry }),
                    app_data = appData
                });
        }

    }
}
