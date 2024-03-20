using AnperoModels;

namespace AnperoControl.Interface
{
    public interface IBuildModuleInteface
    {
      Task<ModuleDataModel?> GetModuleTemplateAsync(AnperoClient client,int moduleId);
    }
}
