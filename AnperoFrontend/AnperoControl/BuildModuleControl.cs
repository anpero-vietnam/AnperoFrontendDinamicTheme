﻿using Anpero.Ultil;
using Anpero;
using AnperoControl.Interface;
using AnperoModels;
using ServiceStack.Configuration;
using Microsoft.Extensions.Options;

namespace AnperoControl
{
    public class BuildModuleControl : IBuildModuleInteface
    {
        private readonly AppSettings appSettings;
        private readonly ICacheService cacheService;
        public BuildModuleControl(IOptions<AppSettings> iOptions, ICacheService cacheService)
        {
            appSettings = iOptions.Value;
            this.cacheService = cacheService;
        }
        public async Task<ModuleDataModel?> GetModuleDataAsync(AnperoClient client, int _moduleId)
        {
            var moduleDataModel = new ModuleDataModel();
            string cacheKey = string.Format(AnperoEnum.CacheKey.ModuleKey, _moduleId, client.StoreId);
             
            if (!cacheService.TryGet<ModuleDataModel>(cacheKey, out moduleDataModel))
            {
                var apiUrl = appSettings.ApiUrl.TrimEnd('/');
                moduleDataModel = await HttpHelper<ModuleDataModel?>.GetAsync(apiUrl + "/api/module",new { moduleId = _moduleId }, client) ?? new ModuleDataModel();
                cacheService.Set(cacheKey, moduleDataModel,appSettings.ShortTimeCaching );
            }
            return moduleDataModel;
        }
    }
}
