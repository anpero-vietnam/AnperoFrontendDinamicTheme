using AnperoModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnperoControl.Interface
{
    public interface IAnperoLogger
    {
        void LogError(string message,Exception ex, AnperoClient client);
        void LogInformation(string message,AnperoClient client);
    }
}
