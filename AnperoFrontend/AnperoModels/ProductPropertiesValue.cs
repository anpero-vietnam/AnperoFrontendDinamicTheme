
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace AnperoModels
{
    public class ProductPropertiesValue
    {
        public int Id { get; set; }
        public int PropertiesId { get; set; }
        public string PropertiesName { get; set; } = string.Empty;  
        public int Rank { get; set; }

        public string Values { get; set; } = string.Empty;
        public string Images { get; set; } = string.Empty;
        public string SmallThumb { get; set; } = string.Empty;  
        public bool IsInStock { get; set; }
        public decimal Price { get; set; }


    }
}
