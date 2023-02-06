using CompanyCatalogue.DataAccess;
using CompanyCatalogue.Interfaces;
using CompanyCatalogue.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace CompanyCatalogue.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly CatalogueDbContext _context;

        public EmployeeRepository(CatalogueDbContext context)
        {
            _context = context;
        }

        public async Task Add(Employee employee)
        {
            await _context.AddAsync(employee);
        }

        public async Task<IEnumerable<Employee>> GetAll()
        {
            return await _context.Employees.ToListAsync();
        }

        public async Task<Employee> GetByIdAsync(int id)
        {
            return await _context.Employees.Include(x => x.Subordinates).FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Employee> GetTree(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<Employee> GetTree(Employee employee)
        {
            throw new NotImplementedException();
        }

        public void Update(Employee employee)
        {
            _context.Employees.Update(employee);
        }

        public void Delete(Employee employee)
        {
            _context.Employees.Remove(employee);
        }

        public void Save()
        {
            _context.SaveChangesAsync();
        }
    }
}
