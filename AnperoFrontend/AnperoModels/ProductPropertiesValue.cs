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
