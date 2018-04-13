using System;

namespace RootInsurance.Api
{
    public class ApiManager
    {
        #region Static Properties
        internal static Configuration.Config Config { get; set; }
        internal static WebExtensions.WebHelper WebHelper { get; set; }
        #endregion

        #region Fields
        private RootModules.Quote _quote;
        private RootModules.PolicyHolder _policyHolder;
        #endregion

        #region Properties
        public RootModules.Quote Quote
        {
            get
            {
                if (this._quote == null)
                    this._quote = new RootModules.Quote();
                return this._quote;
            }
        }
        public RootModules.PolicyHolder PolicyHolder
        {
            get
            {
                if (this._policyHolder == null)
                    this._policyHolder = new RootModules.PolicyHolder();
                return this._policyHolder;
            }
        }
        #endregion

        #region ctor
        public ApiManager(Configuration.Config config)
        {
            if (config == null)
                throw new ArgumentNullException("Configuration parameter cannot be null");
            ApiManager.Config = config;
            ApiManager.WebHelper = new WebExtensions.WebHelper(config);
        }
        #endregion


    }
}
