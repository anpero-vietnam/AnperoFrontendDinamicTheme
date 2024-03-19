using Anpero;
using AnperoControl;
using AnperoControl.Inteface;
using AnperoControl.Interface;
using AnperoFrontend.Bussiness;
using AnperoModels;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using Microsoft.Extensions.Options;
using ServiceStack;

namespace AnperoFrontend.Pages
{
    public class ModuleViewComponent : ViewComponent
    {
        private readonly IBuildModuleInteface buildModuleControl;
        
        public ModuleViewComponent(IBuildModuleInteface buildModuleControl)
        {
            this.buildModuleControl = buildModuleControl;
        }
        public IViewComponentResult Invoke(int moduleId,AnperoClient client)
        {
            // Tạo một chuỗi HTML
            if (client != null)
            {
                var xx = buildModuleControl.GetModuleDataAsync(client, moduleId).Result;
                string htmlContent = "<div><h1>This is HTML content returned from ViewComponent</h1></div>";
                var htmlString = new HtmlString(htmlContent);
                return new HtmlContentViewComponentResult(htmlString);
            }
            else
            {
                return (IViewComponentResult)new EmptyResult();
            }
         
        }
    }
}
