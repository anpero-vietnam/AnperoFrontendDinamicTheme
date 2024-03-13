using AnperoModels;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Http;
namespace AnperoFrontend.Bussiness
{
    public class ClientControl : IClientControl
    {
        private readonly AppSettings appSettings;
        private readonly IHttpContextAccessor _httpContextAccessor;
        
        public ClientControl(IOptions<AppSettings> iOptions,IHttpContextAccessor httpContextAccessor) {
            appSettings = iOptions.Value;
            _httpContextAccessor= httpContextAccessor;
        } 
        public AnperoClient GetClient()
        {
            AnperoClient anperoClient = new AnperoClient();

            if (appSettings != null )
            {
                if (appSettings.IsInternal && _httpContextAccessor.HttpContext != null)
                {
                    var request = _httpContextAccessor.HttpContext.Request;
                    var rawUrl = $"{request.Scheme}://{request.Host}";
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
