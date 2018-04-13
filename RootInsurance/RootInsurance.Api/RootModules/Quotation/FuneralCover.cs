using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RootInsurance.Api.RootModules.Quotation
{
    public class FuneralCover
    {

        #region Methods
        /// <summary>
        /// Requests a quotation for funeral cover
        /// </summary>
        /// <param name="coverAmount">The amount to cover in cents</param>
        /// <param name="hasSpouse">Should a spouse also be covered</param>
        /// <param name="numberOfChildren">Number of children to include in the policy. Should be between 0 and 8, inclusive.</param>
        /// <param name="extendedFamilyAges">Ages of extended family members to cover</param>
        /// <returns></returns>
        public async Task<List<Models.QuoteResponse>> RequestQuote(int coverAmount, bool hasSpouse, int numberOfChildren, int[] extendedFamilyAges)
        {
            // Validate cover amount
            var realCoverAmount = (coverAmount / 100);
            if (realCoverAmount < 10000 || realCoverAmount > 50000)
                throw new Common.ValidationException("The cover amount should be between 10 000 and 50 0000");
            if (numberOfChildren > 8)
                throw new Common.ValidationException("The maximum number of children is limited to 8");
            // Initialise the extended family ages
            if (extendedFamilyAges == null)
                extendedFamilyAges = new int[] { };
            // Validate the number of children and spouse with the extended family ages
            if (numberOfChildren != extendedFamilyAges.Length)
                throw new Common.ValidationException("The number children and spouse does not correspond to the extended family ages");
            return await ApiManager.WebHelper.CallWebApi<List<Models.QuoteResponse>>("quotes", new System.Net.Http.HttpMethod("POST"), 
                new
                {
                    type = Common.QuoteTypes.QuoteTypeFuneral,
                    cover_amount = coverAmount,
                    has_spouse = hasSpouse,
                    number_of_children = numberOfChildren,
                    extended_family_ages = extendedFamilyAges
                });
        }
        #endregion
    }
}
