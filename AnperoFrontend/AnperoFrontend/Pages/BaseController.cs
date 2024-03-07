using Anpero;
using Anpero.Ultil;
using AnperoModels;
using Microsoft.AspNetCore.Mvc.RazorPages;


namespace AnperoFrontend.Pages
{
    public class BaseController : PageModel
    {
        private string rawUrl { get; set; } = string.Empty;

        ICacheService cacheService = new CacheService();
        public void OnGet()
        {


        }
        public AnperoClient clientso
        {

            get
            {
                var rawUrl2 = $"{Request.Scheme}://{Request.Host}";
                return new AnperoClient();
            }
            set { }
        }
    }

}
