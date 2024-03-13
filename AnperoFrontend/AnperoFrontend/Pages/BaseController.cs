using Anpero;
using Anpero.Ultil;
using AnperoFrontend.Bussiness;
using AnperoModels;
using AnperoControl;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System.Configuration;
using System.Security.AccessControl;
using AnperoControl.Inteface;

namespace AnperoFrontend.Pages
{
    public class BaseController : PageModel
    {

        private readonly ICommonDataControl commonDataControl;        
        readonly IClientControl clientControl;        

        public BaseController(IClientControl iClient, ICommonDataControl commonDataControl)
        {
            
            clientControl = iClient;
            this.commonDataControl = commonDataControl;            
        }
        public  void OnGet()
        {
            InitCommonDataData();
            
        }
        private  void InitCommonDataData()
        {   
            ViewData["commonData"] = commonDataControl.GetCommonDataModel(anperoClient).Result;
        }
        public AnperoClient anperoClient
        {
            get
            {                
                return clientControl.GetClient();
            }
        }
      
        public  string GetContent(int moduleId)
        {            
            return "<p>blabla @RenderBody()</p>";
        }

    }

}
