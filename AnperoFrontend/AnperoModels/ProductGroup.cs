using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnperoModels
{
    public class ProductGroup
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Desc { get; set; } = string.Empty;
        public string Images { get; set; } = string.Empty;          
        public int Rank { get; set; }
    }
}
