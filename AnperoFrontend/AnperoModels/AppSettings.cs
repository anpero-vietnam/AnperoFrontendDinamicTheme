
namespace AnperoModels
{
    public class AppSettings
    {
        public bool IsInternal { get; set; } = true;
        public string ClientId { get; set; } = string.Empty;
        public string TokenKey { get; set; } = string.Empty;
        public string ApiUrl { get; set; } = string.Empty;
        public bool IsUsingRedisCache { get; set; } = false;
        public string RedisServerIp { get; set; } = string.Empty;
        public int? RedisPort { get; set; }
        public string? RedisPass { get; set; }
        public int ShortTimeCaching { get; set; } = 0;



    }
}
