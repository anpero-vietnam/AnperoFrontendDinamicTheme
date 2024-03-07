using AnperoFrontend.Bussiness;
using Microsoft.Extensions.Options;

namespace AnperoFrontend.Pages
{
    public class IndexModel : BaseController
    {

        private readonly ILogger<IndexModel> _logger;

        
        public IndexModel(ILogger<IndexModel> logger,IOptions<AppSettings> iOptions, IClientControl iClient) : base(iOptions, iClient)
        {
            var x = iClient;
            var x2 = iClient.GetClient(iOptions.Value, "s"); 
            var rawUrl = $"{Request.Scheme}://{Request.Host}";
            _logger = logger;
           
        }
     

    }
} 