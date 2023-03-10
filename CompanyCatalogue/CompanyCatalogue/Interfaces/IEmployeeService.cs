using CompanyCatalogue.Models;

namespace CompanyCatalogue.Interfaces
{
    public interface IEmployeeService
    {
        Task<Employee> GetLowerLevel(int id);

        Task<Employee> GetFullTree(Employee employee);
    }
}
