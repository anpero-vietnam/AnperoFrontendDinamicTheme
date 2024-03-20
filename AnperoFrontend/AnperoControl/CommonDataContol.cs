using Anpero;
using Anpero.Ultil;
using AnperoControl.Inteface;
using AnperoControl.Interface;
using AnperoModels;
using Microsoft.Extensions.Options;
using ServiceStack.Logging;

namespace AnperoControl
{
    public class CommonDataControl : ICommonDataControl
    {
        private readonly AppSettings appSettings;
        private readonly ICacheService cacheService;
        private readonly IAnperoLogger _logger;
        
        public CommonDataControl(IOptions<AppSettings> iOptions, ICacheService cacheService, IAnperoLogger logger)
        {
            appSettings = iOptions.Value;
            this.cacheService = cacheService;
            _logger = logger;
        }
        public async Task<CommonDataModel?> GetCommonData(AnperoClient client)
        {
            var commonDataModel = new CommonDataModel();
            try
            {
                string cacheKey = string.Format(AnperoEnum.CacheKey.CommonDataCacheKey, client.StoreId);
                if (!cacheService.TryGet<CommonDataModel>(cacheKey, out commonDataModel))
                {
                    var apiUrl = appSettings.ApiUrl.TrimEnd('/');
                    commonDataModel = await HttpHelper<CommonDataModel?>.Post(apiUrl + "/api/CommonData", client) ?? new CommonDataModel();
                    cacheService.Set(cacheKey, commonDataModel, 1);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError("Exception from CommonDataControl => GetCommonData", ex,client);
            }
            return commonDataModel;
        }
    }
}