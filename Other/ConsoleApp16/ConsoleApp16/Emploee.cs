using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp16
{
    class Emploee
    {
        public int IdProj { get; set; }
        public string LastName{ get; set; }
        public int Age { get; set; }
        public Emploee(int id, string lastName, int age)
        {
            IdProj = id;
            this.Age = age;
            this.LastName = lastName;
        }


    }
}
