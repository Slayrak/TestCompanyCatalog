using Bogus;
using CompanyCatalogue.Models;
using Microsoft.EntityFrameworkCore;

namespace CompanyCatalogue.DataAccess
{
    public static class DataGenerator
    {
        //public static List<Employee> Generate()
        //{
        //    var result = new List<Employee>();

        //    var sublist = new List<Employee>();

        //    int startIndex = 0;
        //    int lastIndex = 500;

        //    var id = 1;

        //    Employee employee;

        //    for (int i = 0; i < 50000; i++)
        //    {
        //        var fake = new Faker<Employee>("uk")
        //        .RuleFor(x => x.Fullname, x => x.Person.FullName)
        //        .RuleFor(x => x.Salary, x => x.Random.Number(1000, 3000))
        //        .RuleFor(x => x.DateOfEmployment, x => x.Date.Recent())
        //        .RuleFor(x => x.Position, x => x.Name.JobTitle())
        //        .RuleFor(x => x.Id, x => id++);

        //        employee = fake.Generate();

        //        result.Add(employee);
        //    }

        //    for (int i = 0; i < lastIndex; i++)
        //    {
        //        var rnd = new Random();

        //        var numOfSubs = rnd.Next(1, 6);

        //        sublist = new List<Employee>();

        //        for (int j = 0; j < numOfSubs; j++)
        //        {
        //            var fake = new Faker<Employee>("uk")
        //            .RuleFor(x => x.Fullname, x => x.Person.FullName)
        //            .RuleFor(x => x.Salary, x => x.Random.Number(1000, 3000))
        //            .RuleFor(x => x.DateOfEmployment, x => x.Date.Recent())
        //            .RuleFor(x => x.Position, x => x.Name.JobTitle())
        //            .RuleFor(x => x.Id, x => id++);

        //            employee = fake.Generate();

        //            employee.BossId = result[i].Id;

        //            sublist.Add(employee);

        //            result.Add(employee);
        //        }
        //    }

        //    startIndex = lastIndex;

        //    lastIndex = result.Count;

        //    for (int i = startIndex; i < lastIndex; i++)
        //    {
        //        var rnd = new Random();

        //        var numOfSubs = rnd.Next(1, 6);

        //        sublist = new List<Employee>();

        //        for (int j = 0; j < numOfSubs; j++)
        //        {
        //            var fake = new Faker<Employee>("uk")
        //            .RuleFor(x => x.Fullname, x => x.Person.FullName)
        //            .RuleFor(x => x.Salary, x => x.Random.Number(1000, 3000))
        //            .RuleFor(x => x.DateOfEmployment, x => x.Date.Recent())
        //            .RuleFor(x => x.Position, x => x.Name.JobTitle())
        //            .RuleFor(x => x.Id, x => id++);

        //            employee = fake.Generate();

        //            employee.BossId = result[i].Id;

        //            sublist.Add(employee);

        //            result.Add(employee);
        //        }
        //    }

        //    startIndex = lastIndex;

        //    lastIndex = result.Count;

        //    for (int i = startIndex; i < lastIndex; i++)
        //    {
        //        var rnd = new Random();

        //        var numOfSubs = rnd.Next(1, 6);

        //        sublist = new List<Employee>();

        //        for (int j = 0; j < numOfSubs; j++)
        //        {
        //            var fake = new Faker<Employee>("uk")
        //            .RuleFor(x => x.Fullname, x => x.Person.FullName)
        //            .RuleFor(x => x.Salary, x => x.Random.Number(1000, 3000))
        //            .RuleFor(x => x.DateOfEmployment, x => x.Date.Recent())
        //            .RuleFor(x => x.Position, x => x.Name.JobTitle())
        //            .RuleFor(x => x.Id, x => id++);

        //            employee = fake.Generate();

        //            employee.BossId = result[i].Id;

        //            sublist.Add(employee);

        //            result.Add(employee);
        //        }
        //    }

        //    startIndex = lastIndex;

        //    lastIndex = result.Count;

        //    for (int i = startIndex; i < lastIndex; i++)
        //    {
        //        var rnd = new Random();

        //        var numOfSubs = rnd.Next(1, 6);

        //        sublist = new List<Employee>();

        //        for (int j = 0; j < numOfSubs; j++)
        //        {
        //            var fake = new Faker<Employee>("uk")
        //            .RuleFor(x => x.Fullname, x => x.Person.FullName)
        //            .RuleFor(x => x.Salary, x => x.Random.Number(1000, 3000))
        //            .RuleFor(x => x.DateOfEmployment, x => x.Date.Recent())
        //            .RuleFor(x => x.Position, x => x.Name.JobTitle())
        //            .RuleFor(x => x.Id, x => id++);

        //            employee = fake.Generate();

        //            employee.BossId = result[i].Id;

        //            sublist.Add(employee);

        //            result.Add(employee);
        //        }
        //    }

        //    return result;

        //}

        public static void GenerateOldWay(CatalogueDbContext dbContext)
        {
            if(!dbContext.Employees.Any())
            {
                var result = new List<Employee>();

                var sublist = new List<Employee>();

                int startIndex = 0;
                int lastIndex = 500;

                var id = 1;

                Employee employee;

                for (int i = 0; i < lastIndex; i++)
                {
                    var fake = new Faker<Employee>("uk")
                    .RuleFor(x => x.Fullname, x => x.Person.FullName)
                    .RuleFor(x => x.Salary, x => x.Random.Number(1000, 3000))
                    .RuleFor(x => x.DateOfEmployment, x => x.Date.Recent())
                    .RuleFor(x => x.Position, x => x.Name.JobTitle());

                    employee = fake.Generate();

                    result.Add(employee);
                }

                dbContext.AddRange(result);
                dbContext.SaveChanges();

                for (int i = 0; i < lastIndex; i++)
                {
                    var rnd = new Random();

                    var numOfSubs = rnd.Next(1, 6);

                    sublist = new List<Employee>();

                    for (int j = 0; j < numOfSubs; j++)
                    {
                        var fake = new Faker<Employee>("uk")
                        .RuleFor(x => x.Fullname, x => x.Person.FullName)
                        .RuleFor(x => x.Salary, x => x.Random.Number(1000, 3000))
                        .RuleFor(x => x.DateOfEmployment, x => x.Date.Recent())
                        .RuleFor(x => x.Position, x => x.Name.JobTitle());

                        employee = fake.Generate();

                        employee.BossId = result[i].Id;

                        sublist.Add(employee);

                        result.Add(employee);
                    }
                }

                dbContext.AddRange(result.GetRange(lastIndex, result.Count - lastIndex));
                dbContext.SaveChanges();

                startIndex = lastIndex;
                lastIndex = result.Count;

                for (int i = startIndex; i < lastIndex; i++)
                {
                    var rnd = new Random();

                    var numOfSubs = rnd.Next(1, 6);

                    sublist = new List<Employee>();

                    for (int j = 0; j < numOfSubs; j++)
                    {
                        var fake = new Faker<Employee>("uk")
                        .RuleFor(x => x.Fullname, x => x.Person.FullName)
                        .RuleFor(x => x.Salary, x => x.Random.Number(1000, 3000))
                        .RuleFor(x => x.DateOfEmployment, x => x.Date.Recent())
                        .RuleFor(x => x.Position, x => x.Name.JobTitle());

                        employee = fake.Generate();

                        employee.BossId = result[i].Id;

                        sublist.Add(employee);

                        result.Add(employee);
                    }
                }

                dbContext.AddRange(result.GetRange(lastIndex, result.Count - lastIndex));
                dbContext.SaveChanges();

                startIndex = lastIndex;
                lastIndex = result.Count;

                for (int i = startIndex; i < lastIndex; i++)
                {
                    var rnd = new Random();

                    var numOfSubs = rnd.Next(1, 6);

                    sublist = new List<Employee>();

                    for (int j = 0; j < numOfSubs; j++)
                    {
                        var fake = new Faker<Employee>("uk")
                        .RuleFor(x => x.Fullname, x => x.Person.FullName)
                        .RuleFor(x => x.Salary, x => x.Random.Number(1000, 3000))
                        .RuleFor(x => x.DateOfEmployment, x => x.Date.Recent())
                        .RuleFor(x => x.Position, x => x.Name.JobTitle());

                        employee = fake.Generate();

                        employee.BossId = result[i].Id;

                        sublist.Add(employee);

                        result.Add(employee);
                    }
                }

                dbContext.AddRange(result.GetRange(lastIndex, result.Count - lastIndex));
                dbContext.SaveChanges();

                startIndex = lastIndex;
                lastIndex = result.Count;

                for (int i = startIndex; i < lastIndex; i++)
                {
                    var rnd = new Random();

                    var numOfSubs = rnd.Next(1, 6);

                    sublist = new List<Employee>();

                    for (int j = 0; j < numOfSubs; j++)
                    {
                        var fake = new Faker<Employee>("uk")
                        .RuleFor(x => x.Fullname, x => x.Person.FullName)
                        .RuleFor(x => x.Salary, x => x.Random.Number(1000, 3000))
                        .RuleFor(x => x.DateOfEmployment, x => x.Date.Recent())
                        .RuleFor(x => x.Position, x => x.Name.JobTitle());

                        employee = fake.Generate();

                        employee.BossId = result[i].Id;

                        sublist.Add(employee);

                        result.Add(employee);
                    }
                }

                dbContext.AddRange(result.GetRange(lastIndex, result.Count - lastIndex));
                dbContext.SaveChanges();

            }
        }
    }
}
