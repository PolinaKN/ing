using System;
using System.Collections.Generic;
using System.Linq;


namespace ConsoleApp16
{
    class InfoCompany
    {
        public List<ItCompany> ItCompanies { get; set; }
        public List<Emploee> Emploees { get; set; }
        public List<Project> Projects { get; set; }

        public InfoCompany(List<Emploee> emploees, List<Project> projects, List<ItCompany> itCompanies)
        {
            ItCompanies = itCompanies;
            Emploees = emploees;
            Projects = projects;
        }
       
        public void CoutEmp()
        {
            var countEmp = from e in Emploees
                           group e by e.LastName into person
                           where (person.Count() >= 2)
                           orderby person.Key
                           select new
                           {
                               Name = person.Key,
                               countPersone = person.Count()
                           };

            foreach (var group in countEmp)
            {
                Console.WriteLine($"{group.Name} : {group.countPersone}");
            }

        }

        public void DateProject(DateTime thisTime)
        {
            var dateStart = from date in Projects
                            where (date.StartTime >= thisTime)
                            orderby date.StartTime
                            select new
                            {
                                ProjectName = date.Name,
                                Date = date.StartTime
                            };
            foreach (var item in dateStart)
            {
                Console.WriteLine($"{item.ProjectName} : {item.Date}");
            }
        }
        public void ProjectOneYear()
        {
            var countProj = from proj in Projects
                            group proj by proj.Name into p
                            select new
                            {
                                Count = from pd in p
                                        join emp in Emploees
                                        on pd.IdCompany equals emp.IdProj
                                        where ((pd.StartTime >= DateTime.UtcNow.AddYears(-1)) && (emp.Age < 30))
                                        select new
                                        {
                                            Name = pd.Name
                                        }
                            };

            foreach (var item in countProj)
            {
                foreach (var i in item.Count)
                {
                    Console.WriteLine(i.Name);
                }
            }
        }

        public void NameEmployee()
        {
            var countEmp = from e in Emploees
                           orderby e.Age descending
                           group e by e.LastName into person
                           where (person.Count() == 1 )
                           select new
                           {
                               //Name = person.Key
                               NameEmp = from proj in Projects
                                         where (proj.StartTime >= new DateTime(2019, 1, 1))
                                         //orderby em.Age descending
                                         join emp in person
                                         on proj.IdEmployee equals emp.IdProj
                                         
                                         
                                         select new
                                         {
                                             Name = emp.LastName
                                         }
                           };
           // Console.WriteLine(countEmp.FirstOrDefault().NameEmp.FirstOrDefault().Name);

            foreach (var item in countEmp)
            {
                foreach (var i in item.NameEmp)
                {
                    Console.WriteLine(i.Name);
                }
            }

            
        }

    }
}
