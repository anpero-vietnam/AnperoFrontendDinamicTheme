
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

        


        public IndexModel(IClientControl iClient, ICommonDataControl commonDataContol) : base (iClient, commonDataContol)
        {
            
        }
     
     
    }
} 