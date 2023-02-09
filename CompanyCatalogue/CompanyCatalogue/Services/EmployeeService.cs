using CompanyCatalogue.Interfaces;
using CompanyCatalogue.Models;
using Newtonsoft.Json;

namespace CompanyCatalogue.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeService(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public async Task<Employee> GetLowerLevel(int id)
        {
            var test = await _employeeRepository.GetByIdAsync(id);


            if(test.Subordinates != null)
            {
                for (int i = 0; i < test.Subordinates.Count(); i++)
                {
                    if(test.Subordinates[i].Subordinates == null)
                    {
                        test.Subordinates[i].Subordinates = new List<Employee>();
                    }
                }
            }
            else
            {
                test.Subordinates = new List<Employee>();
            }

            return test;
        }

        public async Task<Employee> GetUpperLevel(Employee employee)
        {
            throw new NotImplementedException();
        }

        public async Task<Employee> GoLower(Employee employee)
        {
            List<Employee> employees = new List<Employee>();

            if(employee.Subordinates != null)
            {
                for (int i = 0; i < employee.Subordinates.Count; i++)
                {
                    Employee res = await _employeeRepository.GetByIdAsync(employee.Subordinates[i].Id);

                    if(res.Subordinates == null)
                    {
                        employees.Add(res);
                        continue;
                    }

                    res = await GoLower(employee.Subordinates[i]);
                    employees.Add(res);
                }
            }

            employee.Subordinates = employees;

            return employee;
        }

        public async Task<Employee> GetFullTree(Employee employee)
        {
            Employee superBoss = employee;

            while (superBoss.BossId != null)
            {
                superBoss = await _employeeRepository.GetByIdAsync((int)superBoss.BossId);
            }

            superBoss = await GoLower(superBoss);

            return superBoss;
        }

    }
}
