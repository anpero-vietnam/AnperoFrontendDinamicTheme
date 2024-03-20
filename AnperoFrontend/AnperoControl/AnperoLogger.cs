using AnperoControl.Interface;
using AnperoModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnperoControl
{
    public class AnperoLogger: IAnperoLogger
    {
        public void LogError(string message,Exception ex, AnperoClient client) { 
        
        }        
        public void LogInformation(string message, AnperoClient client)
        {

        }
    }
}
