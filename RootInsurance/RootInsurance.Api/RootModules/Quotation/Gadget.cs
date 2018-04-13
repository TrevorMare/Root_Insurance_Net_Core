using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RootInsurance.Api.RootModules.Quotation
{
    public class Gadget
    {

        #region Fields

        #endregion

        #region Methods
        /// <summary>
        /// Retrieves a list of gadget models
        /// </summary>
        /// <returns></returns>
        public async Task<List<Models.QuoteGadgetModel>> ListQuoteGadgetModels()
        {
            return await ApiManager.WebHelper.CallWebApi<List<Models.QuoteGadgetModel>>("/modules/root_gadgets/models", new System.Net.Http.HttpMethod("GET"), null);
        }

        public async Task<List<Models.QuoteResponse>> RequestQuote(string modelName)
        {
            return await ApiManager.WebHelper.CallWebApi<List<Models.QuoteResponse>>("quotes", new System.Net.Http.HttpMethod("POST"), new { type = Common.QuoteTypes.QuoteTypeGadget, model_name = modelName });
        }
        #endregion

    }
}
