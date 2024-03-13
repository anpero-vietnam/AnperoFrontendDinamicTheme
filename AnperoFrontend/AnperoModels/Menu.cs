using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnperoModels
{
    public class Menu
    {
        public Menu()
        {
            ChidMenu = new List<Menu>();
        }
        public List<Menu> ChidMenu { get; set; }
        public int Id { get; set; }
        public string Link { get; set; }
        public int ParentId { get; set; }
        public int Prioty { get; set; }
        public string Tittle { get; set; }
    }
}
