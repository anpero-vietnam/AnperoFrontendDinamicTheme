using AnperoModels;
using Anpero.Ultil;
using Microsoft.Extensions.Options;
using AnperoControl.Inteface;
using Anpero;

namespace AnperoControl
{
    public class CommonDataControl: ICommonDataControl
    {
        private readonly AppSettings appSettings;
        private readonly ICacheService cacheService;
        public CommonDataControl(IOptions<AppSettings> iOptions,ICacheService cacheService)
        {
            appSettings = iOptions.Value;
            this.cacheService=cacheService;
        }
        public async Task<CommonDataModel?> GetCommonDataModel(AnperoClient client)
        {
           
            var commonDataModel = new CommonDataModel();    
           if(!cacheService.TryGet<CommonDataModel>("test", out commonDataModel))
            {
                var apiUrl = appSettings.ApiUrl.TrimEnd('/');
                commonDataModel= await HttpHelper<CommonDataModel?>.Post(apiUrl + "/api/CommonData", client) ?? new CommonDataModel();
                cacheService.Set("test", commonDataModel,1);


            }
           
            return commonDataModel;
        }
    }
}