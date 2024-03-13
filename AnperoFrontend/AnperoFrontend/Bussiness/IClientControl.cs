using AnperoModels;

namespace AnperoFrontend.Bussiness
{
    public interface IClientControl
    {
        AnperoClient GetClient(string currentRawUrl);
    }
}
