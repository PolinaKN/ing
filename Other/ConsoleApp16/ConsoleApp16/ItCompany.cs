using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp16
{
    class ItCompany
    {
        public int IdCompany { get; set; }
        public string Name { get; set; }
        public ItCompany(int idCompany, string name )
        {
            IdCompany = idCompany;
            this.Name = name;
            
        }
    }
}
