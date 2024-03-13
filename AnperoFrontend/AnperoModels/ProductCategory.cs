using Anpero.Ultil;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnperoModels
{
    public class ProductCategory
    {
     
        public int Rank { get; set; }
        
        List<ProductCategory> childCategory;     
        public string DefaultLink
        {
            get
            {
                if (string.IsNullOrEmpty(DefaultLink))
                {
                    return "/" + Name.ToUrl().ToLower() + "-c" + Id;
                }
                else
                {
                    return DefaultLink;
                }
            }
            set
            {
                DefaultLink = value;
            }

        }
        public string Name { get; set; } = string.Empty;
        public int Id { get; set; }

        public List<ProductCategory> ChildCategory { get; set; }

        public string Images { get; set; }=string.Empty;    

        public string Keywords { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;
    }
}
