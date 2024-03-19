using System.Text.Json;

namespace AnperoModels
{
    public class ProductPropertiesModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Images { get; set; } = string.Empty;
        public int Rank { get; set; }
        public string Description { get; set; } = string.Empty;
        public string Keywords { get; set; } = string.Empty;
        public string ProductPropertiesValueJson { get; set; } = string.Empty;

        public List<ProductPropertiesValue>? Values
        {
            get
            {
                if (!string.IsNullOrEmpty(ProductPropertiesValueJson))
                {
                    return JsonSerializer.Deserialize<List<ProductPropertiesValue>?>(ProductPropertiesValueJson);
                }
                else
                {
                    return new List<ProductPropertiesValue>();
                }

            }

        }

    }
}
