using AnperoModels;
using Anpero.Ultil;
using Microsoft.Extensions.Options;
using AnperoControl.Inteface;

namespace AnperoControl
{
    public class CommonDataControl: ICommonDataControl
    {
        private readonly AppSettings appSettings;
        public CommonDataControl(IOptions<AppSettings> iOptions)
        {
            appSettings = iOptions.Value;
        }
        public CommonDataModel? GetCommonDataModel(AnperoClient client)
        {
           var  apiUrl =  appSettings.ApiUrl.TrimEnd('/');
           return HttpHelper<CommonDataModel?>.Post(apiUrl+ "/api/CommonData", client)??new CommonDataModel();
        }
    }
}