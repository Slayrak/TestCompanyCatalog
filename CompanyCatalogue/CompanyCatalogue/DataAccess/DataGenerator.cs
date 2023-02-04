using Bogus;
using CompanyCatalogue.Models;

namespace CompanyCatalogue.DataAccess
{
    public static class DataGenerator
    {
        public static void Generate()
        {
            int count = 0;

            while(count < 50000)
            {
                var fake = new Faker<Employee>("uk")
                    .RuleFor(x => x.Fullname, x => x.Person.FullName)
                    .RuleFor(x => x.DateOfEmployment, x => x.Date.Recent())
                    .RuleFor(x => x.Position, x => x.Name.JobTitle());
                    
                count++;
            }
        }
    }
}
