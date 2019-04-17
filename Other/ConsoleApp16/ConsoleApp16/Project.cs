using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp16
{
    class Project
    {
        public int IdCompany { get; set; }
        public int IdEmployee { get; set; }
        public string Name { get; set; }
        public DateTime StartTime{ get; set; }
        
        public Project(int idEmployee,int idCompany, string name, DateTime startTime)
        {
            IdEmployee = idEmployee;
            IdCompany = idCompany;
            Name = name;            
            StartTime = startTime;
        }
    }
}
