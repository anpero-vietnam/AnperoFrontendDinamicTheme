using Anpero;
using AnperoControl.Inteface;
using AnperoFrontend.Bussiness;
using AnperoModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace AnperoFrontend.Pages
{
    public class IndexModel : BaseController
    {

        
        private readonly IClientControl _client;
        private readonly ICommonDataControl commonDataContol;


        public IndexModel(IClientControl iClient, ICommonDataControl commonDataContol) : base (iClient, commonDataContol)
        {
            this.commonDataContol = commonDataContol;   
            _client = iClient;
        }
     
        public string Test()
        {
            
            var rawUrl = $"{Request.Scheme}://{Request.Host}";
            _client.GetClient();
            return "<div>XXXXX</div>";
        }
    }
} 