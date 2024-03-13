using AnperoModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnperoControl.Inteface
{
    public interface ICommonDataControl
    {
        CommonDataModel? GetCommonDataModel(AnperoClient client);
    }
}
