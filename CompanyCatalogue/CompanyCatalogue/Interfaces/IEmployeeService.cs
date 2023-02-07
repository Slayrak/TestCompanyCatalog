using CompanyCatalogue.Models;

namespace CompanyCatalogue.Interfaces
{
    public interface IEmployeeService
    {
        Task<Employee> GetLowerLevel(Employee employee);

        Task<Employee> GetUpperLevel(Employee employee);

        Task<Employee> GetFullTree(Employee employee);
    }
}
