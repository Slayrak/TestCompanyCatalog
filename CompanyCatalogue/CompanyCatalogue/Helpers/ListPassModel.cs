using CompanyCatalogue.Models;

namespace CompanyCatalogue.Helpers
{
    public class ListPassModel
    {
        public IEnumerable<Employee> Employees { get; set; }
        public int Number { get; set; }

        public int MinSalary { get; set; }

        public int MaxSalary { get; set; }
    }
}
