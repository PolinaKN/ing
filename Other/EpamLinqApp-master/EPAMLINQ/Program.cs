using System;
using System.Collections.Generic;
using System.Linq;

public static class DateExtensions
{
    public static bool IsLessThanYearApart(this DateTime date1, DateTime date2)
    {
        return date2.Date.Year - date1.Date.Year <=1 && date2.Date.Month - date1.Date.Month <= 1 && date2.Date.Day - date1.Date.Day <= 1;
    }
}

public class Employee
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Age { get; set; }

}

class Project
{
    public int Id { get; set; }
    public string Name { get; set; }
    public DateTime Date { get; set; }

}

class EmplProj
{
    public int Id { get; set; }
    public int EmplId { get; set; }
    public int ProjId { get; set; }
}
class Company
{
    public int Id { get; set; }
    public string Name { get; set; }
    public List<int> Employees { get; set; }
    public List<int> Projects { get; set; }
}
namespace EPAMLINQ
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Employee> employees = new List<Employee>() {
                new Employee() {Id = 1, Age = 34, Name = "Wes Doyle" },
                new Employee() {Id = 2, Age = 18, Name = "Sara Parker" },
                new Employee() {Id = 3, Age = 45, Name = "Nikolai Ivanov" },
                new Employee() {Id = 5, Age = 38, Name = "Nikolai Petrov" },
                new Employee() {Id = 4, Age = 25, Name = "Anna Romanova" }
            };
            List<Project> projects = new List<Project>()
            {
                new Project() {Id = 1, Date = new DateTime(year:2018, 09, 25), Name = "Task Project Name 1" },
                new Project() {Id = 2, Date = new DateTime(year:2019, 06, 01), Name = "Task Project Name 2" },
                new Project() {Id = 3, Date = new DateTime(year:2014, 03, 16), Name = "Task Project Name 3" },
                new Project() {Id = 5, Date = new DateTime(year:2019, 01, 20), Name = "Task Project Name 5" },
                new Project() {Id = 4, Date = new DateTime(year:2018, 12, 25), Name = "Task Project Name 4" }
            };
            List<EmplProj> emplproj = new List<EmplProj>()
            {
                new EmplProj() { Id = 1, EmplId = 1, ProjId = 2 },
                new EmplProj() { Id = 2, EmplId = 1, ProjId = 4 },
                new EmplProj() { Id = 3, EmplId = 2, ProjId = 1 },
                new EmplProj() { Id = 4, EmplId = 3, ProjId = 3 },
                new EmplProj() { Id = 5, EmplId = 4, ProjId = 1 },
                new EmplProj() { Id = 6, EmplId = 4, ProjId = 3 },
                new EmplProj() { Id = 7, EmplId = 5, ProjId = 5 }
            };
            List<Company> companies = new List<Company>()
            {
                new Company() {Id = 1, Name = "EPAM", Projects = new List<int>() {1, 3}, Employees = new List<int>() { 2, 3, 4 } },
                new Company() {Id = 1, Name = "Nix Solutions", Projects = new List<int>() {2, 4}, Employees = new List<int>() { 1 } }
            };
            Console.WriteLine("query 1\n");

            foreach (var item in employees
                .GroupJoin(emplproj, x => x.Id, c => c.EmplId, (empl, ep) => new {EpName = empl.Name, Count = ep.Count() })
                .Where(x => x.Count == 2)
                .Select(x => x.EpName)
                .OrderBy(x => x)
                .ToList())
                Console.WriteLine(item);

            Console.WriteLine("query 2\n");

            foreach (var item in projects.OrderBy(x => x.Date).ToList())
                Console.WriteLine(item.Name + " " + item.Date.ToShortDateString());

            Console.WriteLine("query 3\n");

            Console.WriteLine(employees
                .Join(emplproj, x => x.Id, p => p.EmplId, (empl, ep) => new { empl.Age, ep.ProjId })
                .Join(projects, x => x.ProjId, c => c.Id, (ep, proj) => new { ep.Age, proj.Date })
                .Where(x=>x.Age<30 && x.Date.IsLessThanYearApart(new DateTime()))
                .Count());

            Console.WriteLine("query 4\n");

            Console.WriteLine(employees
               .GroupJoin(emplproj, x => x.Id, c => c.EmplId, (empl, ep) => new { empl.Name, empl.Age, Eps = ep, count = ep.Count() })
               .Where(x=>x.count == 1)
               .Select(x => new { x.Age, x.Name, x.Eps.First().ProjId })
               .Join(projects, x => x.ProjId, c => c.Id, (empl, proj) => new { empl.Name, empl.Age, proj.Date })
               .Where(x => x.Date.Year == 2019)
               .OrderByDescending(x => x.Age).First().Name);

            //Console.WriteLine(employees
            //    .Join(emplproj, x => x.Id, c => c.EmplId, (empl, ep) => new { empl.Name, empl.Age, ep.ProjId })
            //    .GroupJoin(projects, x => x.ProjId, c => c.Id, (empl, proj) => new {EpName = empl.Name, EpAge = empl.Age, Count = proj.Count(), Projects = proj })
            //    .Where(x => x.Count == 1)
            //    .Select(x => new { Age =  x.EpAge, Name =  x.EpName, Date = x.Projects.First()})
            //    .Where( x=> x.Date.Date.Year == new DateTime().Year)
            //    .OrderByDescending(x=>x.Age).First().Name);

        }
    }
}
