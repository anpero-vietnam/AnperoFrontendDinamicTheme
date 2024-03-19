using AnperoModels;
namespace AnperoControl.Inteface
{
    public interface ICommonDataControl
    {
        Task<CommonDataModel?> GetCommonDataModel(AnperoClient client);
    }
}
