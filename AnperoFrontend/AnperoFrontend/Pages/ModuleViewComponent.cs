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
                var modulData = buildModuleControl.GetModuleTemplateAsync(client, moduleId).Result;                
                var htmlString = new HtmlString(modulData.HTMLContent);
                return new HtmlContentViewComponentResult(htmlString);
            }
            else
            {
                return (IViewComponentResult)new EmptyResult();
            }
         
        }
    }
}
