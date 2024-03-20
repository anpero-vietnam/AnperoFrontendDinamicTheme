using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnperoModels
{
    public partial class BaseClient
    {
        public string Token { get; set; } = string.Empty;
        public string StoreId { get; set; } = string.Empty;
    }
}
