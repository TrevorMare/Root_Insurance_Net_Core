using System;
using System.Collections.Generic;
using System.Text;

namespace RootInsurance.Api.Configuration
{
    public class Config
    {

        #region Fields
        /*
         * Api interface endpoint values
         */
        private string _rootApiBaseUrlSandbox = "https://sandbox.root.co.za/v1/insurance";
        private string _rootApiBaseUrlLive = "https://api.root.co.za/v1/insurance";
        private bool _sandboxMode = false;
        #endregion

        #region Properties
        /// <summary>
        /// Gets or sets a value indicating if this module is working on the sandbox
        /// </summary>
        public bool SandboxMode
        {
            get { return this._sandboxMode; }
            set
            {
                this._sandboxMode = value;
                if (this._sandboxMode == true)
                    this.RootApiBaseUrl = this._rootApiBaseUrlSandbox;
                else
                    this.RootApiBaseUrl = this._rootApiBaseUrlLive;
            }
        }
        /// <summary>
        /// Gets or sets the root Api Base Url. When setting this property, the changes will be lost when setting the sandbox mode property
        /// </summary>
        public string RootApiBaseUrl { get; set; } = "https://api.root.co.za/v1/insurance";
        /// <summary>
        /// Gets or sets the Root Api Key
        /// </summary>
        public string RootApiKey { get; set; } = @"";
        /// <summary>
        /// Gets or sets the Root App Key
        /// </summary>
        public string RootAppKey { get; set; }
        #endregion

    }
}
