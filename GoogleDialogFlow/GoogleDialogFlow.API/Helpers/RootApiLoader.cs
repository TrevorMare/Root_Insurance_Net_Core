using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoogleDialogFlow.API.Helpers
{
    public static class RootApiLoader
    {

        #region Methods
        public static RootInsurance.SDK.ApiManager LoadRootApi()
        {
            RootInsurance.SDK.Configuration.Config configuration = new RootInsurance.SDK.Configuration.Config();
            configuration.RootApiKey = Program.Configuration["RootApiSettings:RootApiKey"].ToString();
            configuration.SandboxMode = Convert.ToBoolean(Program.Configuration["RootApiSettings:SandboxMode"].ToString());
            RootInsurance.SDK.ApiManager apiManager = new RootInsurance.SDK.ApiManager(configuration);
            return apiManager;
        }
        #endregion

    }
}
