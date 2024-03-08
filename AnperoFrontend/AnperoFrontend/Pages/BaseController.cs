using Anpero;
using Anpero.Ultil;
using AnperoFrontend.Bussiness;
using AnperoModels;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System.Configuration;


namespace AnperoFrontend.Pages
{
    public class BaseController : PageModel
    {
        private readonly AppSettings appConfig;
        private readonly ICacheService cacheService = new CacheService();
        readonly IClientControl clientControl;
        public BaseController(IOptions<AppSettings> iOptions, IClientControl iClient, ICacheService icacheService)
        {
            appConfig = iOptions.Value;
            clientControl = iClient;
            cacheService = icacheService;            
        }
        public void OnGet()
        {
            var rawUrl = $"{Request.Scheme}://{Request.Host}";
            var client = clientControl.GetClient(appConfig, rawUrl);
        }
        public  string GetContent(int moduleId)
        {
            return "<p>blabla @RenderBody()</p>";
        }

    }

}
