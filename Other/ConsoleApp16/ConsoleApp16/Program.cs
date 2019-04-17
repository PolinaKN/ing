using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp16
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Emploee> emploees = new List<Emploee>
            {
                new Emploee(1,"Stiv", 31),
                new Emploee(2,"Stiv", 31),
                new Emploee(1,"Bob", 28),
                new Emploee(2,"Mark", 20),
                new Emploee(2,"Tom", 18)
            };

            List<Project> projects = new List<Project>
            {
                new Project(1,1,"MyProject", new DateTime(2012, 10, 2)),
                new Project(2,1,"Helthroject", new DateTime(2019, 2, 5))
            };
            List<ItCompany> itCompanies = new List<ItCompany>
            {
                new ItCompany(1,"AtaStar")
            };

            InfoCompany infoCompany = new InfoCompany(emploees,projects, itCompanies);
            Console.WriteLine();
            infoCompany.CoutEmp();
            Console.WriteLine();
            infoCompany.DateProject(new DateTime(2016, 1, 1));
            Console.WriteLine();
            infoCompany.ProjectOneYear();
            Console.WriteLine();
            infoCompany.NameEmployee();
            

        }  
    }
}
