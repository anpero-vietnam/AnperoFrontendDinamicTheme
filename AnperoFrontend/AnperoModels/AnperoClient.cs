﻿namespace AnperoModels
{
    public class AnperoClient
    {
        public AnperoClient() { }
        public DateTime? ExpirationDate { get; set; }
        public string Token { get; set; } = string.Empty;
        public string ClientId { get; set; } = string.Empty;
    }
}
