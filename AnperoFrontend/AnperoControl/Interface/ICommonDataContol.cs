using AnperoModels;
namespace AnperoControl.Inteface
{
    public interface ICommonDataControl
    {
        Task<CommonDataModel?> GetCommonData(AnperoClient client);
    }
}
