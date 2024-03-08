using Anpero;
using AnperoFrontend.Bussiness;
using AnperoModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace AnperoFrontend.Pages
{
    public class IndexModel : BaseController
    {

        
        private readonly IClientControl _client;
        private readonly AppSettings _appSetting;

        public IndexModel(IOptions<AppSettings> iOptions, IClientControl iClient, ICacheService icacheService) : base(iOptions, iClient, icacheService)
        {
            _appSetting = iOptions.Value;
            _client = iClient;
        }
     
        public string Test()
        {
            var rawUrl = $"{Request.Scheme}://{Request.Host}";
            _client.GetClient(_appSetting,rawUrl);
            return "<div>XXXXX</div>";
        }
    }
} 