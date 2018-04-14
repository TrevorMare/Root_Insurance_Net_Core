using GoogleDialogFlow.API.Core.Interfaces;
using GoogleDialogFlow.API.Data.Interfaces;
using GoogleDialogFlow.API.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoogleDialogFlow.API.DialogFlowActions
{
    public class GenerateQuotation : IDialogFlowAction
    {
        
        #region Properties
        public IState DBState { get; set; }
        public string IntentName { get { return "33_Generate_Quotation"; } }
        #endregion

        #region Methods
        public async Task<IDialogFlowOutput> ExecuteAsync(IDialogFlowInput flowInput)
        {
            var root_context = flowInput.Result.Contexts.FirstOrDefault(c => c.name == "root_context");
            if (root_context == null)
                throw new Exception("Unable to load the root context");
            string sessionId = flowInput.SessionId;
            // Create the root insurance Api
            RootInsurance.SDK.ApiManager apiManager = Helpers.RootApiLoader.LoadRootApi();
            // Now check what type of insurance we should get
            var insuranceType = Helpers.DictionaryHelper.GetValue<string>(root_context?.Parameters, "Insurance_Type");
            if (!string.IsNullOrEmpty(insuranceType))
            {
                List<RootInsurance.SDK.Models.QuoteResponse> quoteResponses = null;
                if (insuranceType == "funeral")
                {
                    var qt_funeral_amount = Helpers.DictionaryHelper.GetValue<int?>(root_context.Parameters, "qt_funeral_amount");
                    if (!qt_funeral_amount.HasValue)
                        throw new Exception("Funeral cover amount is not specified");
                    var qt_funeral_spouse = Helpers.DictionaryHelper.GetValue<bool>(root_context.Parameters, "qt_funeral_spouse");
                    var qt_funeral_has_children = Helpers.DictionaryHelper.GetValue<bool>(root_context.Parameters, "qt_funeral_has_children");
                    int qt_funeral_number_children = 0;
                    if (qt_funeral_has_children == true)
                        qt_funeral_number_children = Helpers.DictionaryHelper.GetValue<int>(root_context.Parameters, "qt_funeral_number_children");
                    var qt_funeral_has_extended = Helpers.DictionaryHelper.GetValue<bool>(root_context.Parameters, "qt_funeral_has_children");
                    List<int> qt_funeral_extended_ages = new List<int>();
                    if (qt_funeral_has_extended == true)
                        qt_funeral_extended_ages = Helpers.DictionaryHelper.GetValue<List<int>>(root_context.Parameters, "qt_funeral_extended_ages");
                    quoteResponses = await apiManager.Quote.FuneralCover.RequestQuote(qt_funeral_amount.Value * 100, qt_funeral_spouse, qt_funeral_number_children, qt_funeral_extended_ages.ToArray());
                }
                else if (insuranceType == "gadget")
                {
                    string gadgetName = Helpers.DictionaryHelper.GetValue<string>(root_context.Parameters, "qt_gadget_name");
                    if (string.IsNullOrEmpty(gadgetName))
                        throw new Exception("Gadget name not specified for quotation");
                    quoteResponses = await apiManager.Quote.Gadget.RequestQuote(gadgetName);
                }
                else if (insuranceType == "life")
                {
                    var qt_life_amount = Helpers.DictionaryHelper.GetValue<int?>(root_context.Parameters, "qt_life_amount");
                    if (!qt_life_amount.HasValue)
                        throw new Exception("Quote life cover amount is not specified");
                    var qt_life_basic = Helpers.DictionaryHelper.GetValue<int?>(root_context.Parameters, "qt_life_basic");
                    if (!qt_life_basic.HasValue)
                        throw new Exception("Quote life basic salary amount is not specified");
                    var qt_life_education = Helpers.DictionaryHelper.GetValue<string>(root_context.Parameters, "qt_life_education");
                    if (string.IsNullOrEmpty(qt_life_education))
                        throw new Exception("Quote life education is not specified");
                    RootInsurance.SDK.Common.E_EducationStatus e_qt_life_education = Enum.Parse<RootInsurance.SDK.Common.E_EducationStatus>(qt_life_education);
                    var qt_life_smoker = Helpers.DictionaryHelper.GetValue<bool>(root_context.Parameters, "qt_life_smoker");
                    var qt_life_gender = Helpers.DictionaryHelper.GetValue<string>(root_context.Parameters, "qt_life_gender");
                    if (string.IsNullOrEmpty(qt_life_gender))
                        throw new Exception("Quote life gender is not specified");
                    RootInsurance.SDK.Common.E_Gender e_qt_life_gender = Enum.Parse<RootInsurance.SDK.Common.E_Gender>(qt_life_gender);
                    var qt_life_age = Helpers.DictionaryHelper.GetValue<int?>(root_context.Parameters, "qt_life_age");
                    if (!qt_life_age.HasValue)
                        throw new Exception("Quote life age is not specified");

                    var qt_life_term = Helpers.DictionaryHelper.GetValue<string>(root_context.Parameters, "qt_life_term");
                    if (string.IsNullOrEmpty(qt_life_term))
                        throw new Exception("Quote life term is not specified");
                    RootInsurance.SDK.Common.E_CoverPeriod e_qt_life_term = Enum.Parse<RootInsurance.SDK.Common.E_CoverPeriod>(qt_life_term);
                    qt_life_basic = qt_life_basic * 100;
                    qt_life_amount = qt_life_amount * 100;
                    quoteResponses = await apiManager.Quote.TermLife.RequestQuote(qt_life_amount.Value, e_qt_life_term, qt_life_basic.Value, e_qt_life_education, qt_life_smoker, e_qt_life_gender, qt_life_age.Value);
                }
                // Save the quote responses
                if (quoteResponses != null && quoteResponses.Count > 0)
                {
                    await DBState.SaveUserQuotation(sessionId, quoteResponses);
                    // Send back the response to either accept or decline the quotation
                    var dialogFlowOutput = new Core.Models.DialogFlowOutput() { };
                    quoteResponses.ForEach(q =>
                    {
                        dialogFlowOutput.Speech += q.PackageName + " for amount " + (q.SuggestedPremium / 100).ToString();
                    });
                    return dialogFlowOutput;
                }
                else
                    throw new Exception($"Unable to generate a quotation for quotation type {insuranceType}");
            }
            else
                throw new Exception($"Quotation insurance type not specified");
        }
        #endregion

    }
}
