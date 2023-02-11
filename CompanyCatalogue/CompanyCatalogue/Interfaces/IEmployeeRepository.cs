using CompanyCatalogue.Helpers;
using CompanyCatalogue.Models;

namespace CompanyCatalogue.Interfaces
{
    public interface IEmployeeRepository
    {
        Task<Employee> GetByIdAsync(int id);

        Task<IEnumerable<Employee>> GetAll();

        Task<IEnumerable<Employee>> GetPage(PageOptions pageOptions);
        Task<IEnumerable<Employee>> GetFilteredPage(PageOptions pageOptions, FilterOptions filterOptions);

        Task<int> CountEntries();

        Task<int> GetMaxSalary();
        Task<int> GetMinSalary();

        Task Add(Employee employee);
        void Update(Employee employee);
        void Delete(Employee employee);
        void Save();
    }
}
