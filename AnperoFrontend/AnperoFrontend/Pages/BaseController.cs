using Anpero;
using Anpero.Ultil;
using AnperoFrontend.Bussiness;
using AnperoModels;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System.Configuration;


namespace AnperoFrontend.Pages
{
    public class BaseController : PageModel
    {
        public readonly AppSettings appConfig;        
        public readonly ICacheService cacheService = new CacheService();
        public readonly IClientControl clientControl;
        public BaseController(IOptions<AppSettings> iOptions, IClientControl iClient, ICacheService icacheService)
        {
            appConfig = iOptions.Value;
            clientControl = iClient;
            cacheService = icacheService;            
        }




        public void OnGet()
        {
            var rawUrl = $"{Request.Scheme}://{Request.Host}";
            var sclient = clientControl.GetClient(appConfig, rawUrl);

        }

    }

}
