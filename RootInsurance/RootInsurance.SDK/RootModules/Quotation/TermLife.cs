using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RootInsurance.SDK.RootModules.Quotation
{
    public class TermLife
    {

        #region Methods
        /// <summary>
        /// Generates a qoute for life insurance
        /// </summary>
        /// <param name="coverAmount">Amount to cover, in cents. Should be between R100 000 and R5 000 000, inclusive</param>
        /// <param name="coverPeriod">Duration to cover: 1_year, 2_years, 5_years, 10_years, 15_years, 20_years or whole_life</param>
        /// <param name="basicIncomePerMonth">Policyholder's basic monthly income, in cents.</param>
        /// <param name="educationStatus">Policyholder’s education class: grade_12_no_matric, grade_12_matric, diploma_or_btech, undergraduate_degree or professional_degree</param>
        /// <param name="smoker">Is the policyholder a smoker.</param>
        /// <param name="gender">Gender of policyholder. Should be either male or female</param>
        /// <param name="age">Age of policyholder. Should be between 18 and 63, inclusive</param>
        /// <returns></returns>
        public async Task<List<Models.QuoteResponse>> RequestQuote(int coverAmount, Common.E_CoverPeriod coverPeriod, int basicIncomePerMonth, Common.E_EducationStatus educationStatus, bool smoker, Common.E_Gender gender, int age)
        {
            var realCoverAmount = (coverAmount / 100);
            if (realCoverAmount <= 100000 || realCoverAmount > 5000000)
                throw new Common.ValidationException("The cover amount should be between R100 000 and R5 000 000");
            if (age < 18 || age > 63)
                throw new Common.ValidationException("The age of the applicant should be between 18 and 63");
            return await ApiManager.WebHelper.CallWebApi<List<Models.QuoteResponse>>("quotes", new System.Net.Http.HttpMethod("POST"), 
                new
                {
                    type = Common.QuoteTypes.QuoteTypeTermLife,
                    cover_amount = coverAmount,
                    cover_period = coverPeriod.ToString().Replace("one", "1").Replace("two", "2").Replace("five", "5").Replace("fifteen", "15").Replace("twenty", "20"),
                    basic_income_per_month = basicIncomePerMonth,
                    education_status = educationStatus.ToString(),
                    smoker = smoker,
                    gender = gender.ToString(),
                    age = age
                });
        }
        /// <summary>
        /// Generates a qoute for life insurance
        /// </summary>
        /// <param name="lifeCoverGetQuote">A strongly typed model of the life cover values</param>
        /// <returns></returns>
        public async Task<List<Models.QuoteResponse>> RequestQuote(Models.LifeCoverGetQuote lifeCoverGetQuote)
        {
            return await this.RequestQuote(lifeCoverGetQuote.CoverAmount, lifeCoverGetQuote.CoverPeriod, lifeCoverGetQuote.BasicIncomePerMonth, lifeCoverGetQuote.EducationStatus, lifeCoverGetQuote.Smoker, lifeCoverGetQuote.Gender, lifeCoverGetQuote.Age);
        }
        #endregion

    }
}
