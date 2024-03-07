namespace AnperoFrontend.Pages
{
    public class IndexModel : BaseController
    {
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {

            _logger = logger;

        }


    }
}