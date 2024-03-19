using AnperoControl.Inteface;
using AnperoFrontend.Bussiness;
using AnperoModels;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AnperoFrontend.Pages
{
    public class BaseController : PageModel
    {

        public readonly ICommonDataControl commonDataControl;
        public readonly IClientControl clientControl;

        public BaseController(IClientControl iClient, ICommonDataControl commonDataControl)
        {

            clientControl = iClient;
            this.commonDataControl = commonDataControl;
        }
        //public  void OnGet()
        //{
        //    InitCommonDataData();

        //}
        //private  void InitCommonDataData()
        //{   

        //}

        public CommonDataModel commonData
        {
            get
            {
                CommonDataModel? _commonData = commonDataControl.GetCommonDataModel(anperoClient).Result;
                return _commonData ?? new CommonDataModel();
            }
        }
        public AnperoClient anperoClient
        {
            get
            {
                return clientControl.GetClient();
            }
        }
        public string CurrentUrl
        {
            get
            {
                return $"{Request.Scheme}://{Request.Host}{Request.Path}{Request.QueryString}";
            }
        }

        public string GetMainLayoutContent()
        {
            return "<p>blabla @RenderBody()</p>";
        }

    }

}
