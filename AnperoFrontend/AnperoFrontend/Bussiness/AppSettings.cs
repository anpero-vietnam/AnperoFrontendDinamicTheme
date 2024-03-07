﻿using Microsoft.Extensions.Options;

namespace AnperoFrontend.Bussiness
{
    public class AppSettings
    {   
        public bool IsInternal { get; set; } = true;
        public string ClientId { get; set; } = string.Empty;
        public string TokenKey { get; set; } = string.Empty;
        
    }
}
