using CompanyCatalogue.Interfaces;
using CompanyCatalogue.Models;

namespace CompanyCatalogue.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeService(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public async Task<Employee> GetLowerLevel(Employee employee)
        {
            throw new NotImplementedException();
        }

        public async Task<Employee> GetUpperLevel(Employee employee)
        {
            throw new NotImplementedException();
        }

        public async Task<Employee> GetFullTree(Employee employee)
        {
            throw new NotImplementedException();
        }

    }
}
