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
        public string DefaultLink { get; set; }=string.Empty;
        public string Link
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
        }
        public string Name { get; set; } = string.Empty;
        public int Id { get; set; }

        public List<ProductCategory> ChildCategory { get; set; }= new List<ProductCategory>();  

        public string Images { get; set; }=string.Empty;    

        public string Keywords { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;
    }
}
