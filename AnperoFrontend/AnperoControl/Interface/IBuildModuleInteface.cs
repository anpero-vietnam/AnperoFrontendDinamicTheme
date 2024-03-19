using AnperoModels;

namespace AnperoControl.Interface
{
    public interface IBuildModuleInteface
    {
      Task<ModuleDataModel?> GetModuleDataAsync(AnperoClient client,int moduleId);
    }
}
