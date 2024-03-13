using AnperoModels;
using Microsoft.Extensions.Options;

namespace AnperoFrontend.Bussiness
{
    public class ClientControl : IClientControl
    {
        private readonly AppSettings appSettings;
        public ClientControl(IOptions<AppSettings> iOptions) {
            appSettings = iOptions.Value;
        } 
        public AnperoClient GetClient(string currentRawUrl)
        {
            AnperoClient anperoClient = new AnperoClient();
            if(appSettings != null && !string.IsNullOrEmpty(currentRawUrl))
            {
                if (appSettings.IsInternal)
                {
                    /// Get client information through the service through the current domain

                }
                else
                {
                    /// get  from appseting file,  used for independent sites deployed
                    anperoClient.StoreId = appSettings.ClientId;
                    anperoClient.Token = appSettings.TokenKey;                   
                }
            }
            return anperoClient;
        }
    }
}
