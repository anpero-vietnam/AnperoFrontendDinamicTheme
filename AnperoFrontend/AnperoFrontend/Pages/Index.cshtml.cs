
using AnperoControl.Inteface;
using AnperoFrontend.Bussiness;
using AnperoModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System.Text;

namespace AnperoFrontend.Pages
{
    public class IndexModel : BaseController
    {

        
        //private readonly IClientControl _client;
        //private readonly ICommonDataControl commonDataContol;


        public IndexModel(IClientControl iClient, ICommonDataControl commonDataContol) : base (iClient, commonDataContol)
        {
            //this.commonDataContol = commonDataContol;   
            //_client = iClient;
        }
     
        public string Test()
        {

            StringBuilder stringBuilder = new StringBuilder();
            
            clientControl.GetClient();
            return "<div>XXXXX</div>";
        }
    }
} 