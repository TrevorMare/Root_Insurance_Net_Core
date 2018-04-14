using System;
using System.Collections.Generic;
using System.Text;

namespace RootInsurance.SDK.Models
{
    public class LifeCoverGetQuote
    {

        #region Properties
        /// <summary>
        /// >Amount to cover, in cents. Should be between R100 000 and R5 000 000, inclusive
        /// </summary>
        public int CoverAmount { get; set; }
        /// <summary>
        /// Duration to cover: 1_year, 2_years, 5_years, 10_years, 15_years, 20_years or whole_life
        /// </summary>
        public Common.E_CoverPeriod CoverPeriod { get; set; }
        /// <summary>
        /// Policyholder's basic monthly income, in cents.
        /// </summary>
        public int BasicIncomePerMonth { get; set; }
        /// <summary>
        /// Policyholder’s education class: grade_12_no_matric, grade_12_matric, diploma_or_btech, undergraduate_degree or professional_degree
        /// </summary>
        public Common.E_EducationStatus EducationStatus { get; set; }
        /// <summary>
        /// Is the policyholder a smoker
        /// </summary>
        public bool Smoker { get; set; }
        /// <summary>
        /// Gender of policyholder. Should be either male or female
        /// </summary>
        public Common.E_Gender Gender { get; set; }
        /// <summary>
        /// Age of policyholder. Should be between 18 and 63, inclusive
        /// </summary>
        public int Age { get; set; }
        #endregion
    }
}
