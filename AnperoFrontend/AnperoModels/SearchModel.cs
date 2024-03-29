﻿namespace AnperoModels
{
    public class SearchModel
    {
        public int StoreId { get; set; }
        public string KeyWord { get; set; }
        public string SortBy { get; set; }
        public string Brands { get; set; }

        public string Category { get; set; }
        public string ParentCategory { get; set; }
        public int PriceFrom { get; set; }
        public int PriceTo { get; set; }
        public int CurentPage { get; set; }
        public int PageSize { get; set; }
        public int MinPrioty { get; set; }
        public int Page { get; set; }
        public string Property { get; set; }
        public string PriceRank
        {
            get
            {
                return priceRank;
            }

            set
            {
                var t = string.IsNullOrEmpty(value);
                if (!string.IsNullOrEmpty(value))
                {

                    try
                    {
                        string[] price = new string[2];
                        if (value.Contains("-"))
                        {
                            price = value.Split('-');
                        }
                        if (price.Length > 1)
                        {
                            PriceFrom = Convert.ToInt32(price[0].Trim());
                            PriceTo = Convert.ToInt32(price[1].Trim());
                        }
                    }
                    catch (Exception)
                    {
                    }

                }
                else
                {
                    PriceFrom = 0;
                    PriceTo = 99999999;
                }
                priceRank = value;
            }
        }

        string priceRank;

        public SearchModel()
        {
            SortBy = "timeDesc";
            Page = 1;
            StoreId = 0;
            KeyWord = string.Empty;
            Category = "%";
            PriceFrom = 0;
            PriceTo = int.MaxValue;
            CurentPage = 1;
            PageSize = 18;
            ParentCategory = "0";
            Brands = string.Empty;
            Property = string.Empty;

        }

    }
}
