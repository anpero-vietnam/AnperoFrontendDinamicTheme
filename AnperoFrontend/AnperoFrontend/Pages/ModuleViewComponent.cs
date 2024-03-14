using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewComponents;

namespace AnperoFrontend.Pages
{
    public class ModuleViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke(int moduleId)
        {
            // Tạo một chuỗi HTML
            string htmlContent = "<div><h1>This is HTML content returned from ViewComponent</h1></div>";
            var htmlString = new HtmlString(htmlContent);
            return new HtmlContentViewComponentResult(htmlString);
        }
    }
}
