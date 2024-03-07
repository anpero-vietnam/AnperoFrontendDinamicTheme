using AnperoModels;
using Microsoft.Extensions.Options;

namespace AnperoFrontend.Bussiness
{
    public class ClientControl : IClientControl
    {
        public ClientControl() { } 
        public AnperoClient GetClient(AppSettings appSettings,string currentRawUrl)
        {
            AnperoClient anperoClient = new AnperoClient();
            if (appSettings.IsInternal)
            {
                /// Get Client from database which Domain
            
            }
            else
            {
                anperoClient.ClientId = appSettings.ClientId;
                anperoClient.Token = appSettings.TokenKey;
                /// get  from appseting file


            }
            return anperoClient;
        }
    }
}
