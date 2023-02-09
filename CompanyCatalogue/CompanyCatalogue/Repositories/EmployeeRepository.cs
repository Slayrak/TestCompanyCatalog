using CompanyCatalogue.DataAccess;
using CompanyCatalogue.Helpers;
using CompanyCatalogue.Interfaces;
using CompanyCatalogue.Models;
using CompanyCatalogue.Models.PassingModels;
using Microsoft.AspNetCore.Mvc;
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

        public async Task<IEnumerable<Employee>> GetPage(PageOptions pageOptions)
        {
            switch (pageOptions.SortProperty)
            {
                case "Name":
                    if (pageOptions.SortingDirection == "Ascending")
                    {
                        return await _context.Employees
                            .OrderBy(x => x.Fullname)
                            .Skip((pageOptions.PageNumber - 1) * pageOptions.PageSize)
                            .Take(pageOptions.PageSize)
                            .ToListAsync();
                    }
                    else
                    {
                        return await _context.Employees
                            .OrderByDescending(x => x.Fullname)
                            .Skip((pageOptions.PageNumber - 1) * pageOptions.PageSize)
                            .Take(pageOptions.PageSize)
                            .ToListAsync();
                    }
                    break;
                case "Position":
                    if (pageOptions.SortingDirection == "Ascending")
                    {
                        return await _context.Employees
                            .OrderBy(x => x.Position)
                            .Skip((pageOptions.PageNumber - 1) * pageOptions.PageSize)
                            .Take(pageOptions.PageSize)
                            .ToListAsync();
                    }
                    else
                    {
                        return await _context.Employees
                             .OrderByDescending(x => x.Position)
                             .Skip((pageOptions.PageNumber - 1) * pageOptions.PageSize)
                             .Take(pageOptions.PageSize)
                             .ToListAsync();
                    }
                    break;
                case "Salary":
                    if (pageOptions.SortingDirection == "Ascending")
                    {
                        return await _context.Employees
                            .OrderBy(x => x.Salary)
                            .Skip((pageOptions.PageNumber - 1) * pageOptions.PageSize)
                            .Take(pageOptions.PageSize)
                            .ToListAsync();
                    }
                    else
                    {
                        return await _context.Employees
                            .OrderByDescending(x => x.Position)
                            .Skip((pageOptions.PageNumber - 1) * pageOptions.PageSize)
                            .Take(pageOptions.PageSize)
                            .ToListAsync();
                    }
                    break;
                case "Date of Employment":
                    if (pageOptions.SortingDirection == "Ascending")
                    {
                        return await _context.Employees
                            .OrderBy(x => x.Position)
                            .Skip((pageOptions.PageNumber - 1) * pageOptions.PageSize)
                            .Take(pageOptions.PageSize)
                            .ToListAsync();
                    }
                    else
                    {
                        return await _context.Employees
                            .OrderByDescending(x => x.Position)
                            .Skip((pageOptions.PageNumber - 1) * pageOptions.PageSize)
                            .Take(pageOptions.PageSize)
                            .ToListAsync();
                    }
                    break;
                default:
                    break;
            }

            return await _context.Employees
                            .OrderBy(x => x.Fullname)
                            .Skip((pageOptions.PageNumber - 1) * pageOptions.PageSize)
                            .Take(pageOptions.PageSize)
                            .ToListAsync();
        }

        public async Task<int> CountEntries()
        {
            return await _context.Employees.CountAsync();
        }

        public async Task<Employee> GetByIdAsync(int id)
        {
            return await _context.Employees.Include(x => x.Subordinates).Include(x => x.Boss).FirstOrDefaultAsync(x => x.Id == id);
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
