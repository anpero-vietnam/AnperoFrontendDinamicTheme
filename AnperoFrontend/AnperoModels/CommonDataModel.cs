namespace AnperoModels
{
    public class CommonDataModel
    {

        public string ServerName { get; set; } = string.Empty;

        public string Token { get; set; } = string.Empty;
        public List<Menu> MenuList { get; set; } = new List<Menu>();
        public List<Menu> FooterMenuList { get; set; } = new List<Menu>();

        public string FaceBookLink { get; set; } = string.Empty;

        public string Skype { get; set; } = string.Empty;

        public string OtherPhone { get; set; } = string.Empty;
        public string HotLine { get; set; } = string.Empty;

        public string PageScript { get; set; } = string.Empty;

        public string Footer { get; set; } = string.Empty;
        public string Logo { get; set; } = string.Empty;
        public string Desc { get; set; } = string.Empty;
        public List<ProductCategory> ProductCategoryList { get; set; } = new List<ProductCategory>();
        public List<ProductGroup> ProductGroupList { get; set; } = new List<ProductGroup>();
        public string Email { get; set; } = string.Empty;

        public string Address { get; set; } = string.Empty;

        public string AnperoPlugin { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public List<ProductPropertiesModel> ProductProperties { get; set; } = new List<ProductPropertiesModel>();
        public string Favicon { get; set; } = string.Empty;
    }
}