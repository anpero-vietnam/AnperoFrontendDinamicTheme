using Anpero;
using Anpero.Ultil;
using AnperoControl.Inteface;
using AnperoModels;
using Microsoft.Extensions.Options;

namespace AnperoControl
{
    public class CommonDataControl : ICommonDataControl
    {
        private readonly AppSettings appSettings;
        private readonly ICacheService cacheService;
        public CommonDataControl(IOptions<AppSettings> iOptions, ICacheService cacheService)
        {
            appSettings = iOptions.Value;
            this.cacheService = cacheService;
        }
        public async Task<CommonDataModel?> GetCommonDataModel(AnperoClient client)
        {

            var commonDataModel = new CommonDataModel();
            string cacheKey = string.Format(AnperoEnum.CacheKey.CommonDataCacheKey, client.StoreId);
            if (!cacheService.TryGet<CommonDataModel>(cacheKey, out commonDataModel))
            {
                var apiUrl = appSettings.ApiUrl.TrimEnd('/');
                commonDataModel = await HttpHelper<CommonDataModel?>.Post(apiUrl + "/api/CommonData", client) ?? new CommonDataModel();
                cacheService.Set(cacheKey, commonDataModel, 1);
            }

            return commonDataModel;
        }
    }
}