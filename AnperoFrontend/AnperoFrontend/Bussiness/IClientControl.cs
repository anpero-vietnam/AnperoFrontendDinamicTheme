using AnperoModels;

namespace AnperoFrontend.Bussiness
{
    public interface IClientControl
    {
        AnperoClient GetClient(AppSettings appSettings, string currentRawUrl);
    }
}
