using CompanyCatalogue.DataAccess;
using CompanyCatalogue.Helpers;
using CompanyCatalogue.Interfaces;
using CompanyCatalogue.Models;
using Microsoft.EntityFrameworkCore;

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
                default:
                    break;
            }

            return await _context.Employees
                            .OrderBy(x => x.Fullname)
                            .Skip((pageOptions.PageNumber - 1) * pageOptions.PageSize)
                            .Take(pageOptions.PageSize)
                            .ToListAsync();
        }

        public async Task<IEnumerable<Employee>> GetFilteredPage(PageOptions pageOptions, FilterOptions filterOptions)
        {
            switch (pageOptions.SortProperty)
            {
                case "Name":
                    if (pageOptions.SortingDirection == "Ascending")
                    {
                        return await _context.Employees
                            .Where(x =>
                                ((x.Fullname == filterOptions.EmployeeName && filterOptions.EmployeeName != null)
                                || (x.Fullname == x.Fullname && filterOptions.EmployeeName == null)) &&
                                ((x.Position == filterOptions.Position && filterOptions.Position != null) ||
                                (x.Position == x.Position && filterOptions.Position == null)) &&
                                (x.Salary >= filterOptions.min) &&
                                (x.Salary <= filterOptions.max)
                                )
                            .OrderBy(x => x.Fullname)
                            .Skip((pageOptions.PageNumber - 1) * pageOptions.PageSize)
                            .Take(pageOptions.PageSize)
                            .ToListAsync();
                    }
                    else
                    {
                        return await _context.Employees
                            .Where(x =>
                                ((x.Fullname == filterOptions.EmployeeName && filterOptions.EmployeeName != null)
                                || (x.Fullname == x.Fullname && filterOptions.EmployeeName == null)) &&
                                ((x.Position == filterOptions.Position && filterOptions.Position != null) ||
                                (x.Position == x.Position && filterOptions.Position == null)) &&
                                (x.Salary >= filterOptions.min) &&
                                (x.Salary <= filterOptions.max)
                                )
                            .OrderByDescending(x => x.Fullname)
                            .Skip((pageOptions.PageNumber - 1) * pageOptions.PageSize)
                            .Take(pageOptions.PageSize)
                            .ToListAsync();
                    }
                case "Position":
                    if (pageOptions.SortingDirection == "Ascending")
                    {
                        return await _context.Employees
                            .Where(x =>
                                ((x.Fullname == filterOptions.EmployeeName && filterOptions.EmployeeName != null)
                                || (x.Fullname == x.Fullname && filterOptions.EmployeeName == null)) &&
                                ((x.Position == filterOptions.Position && filterOptions.Position != null) ||
                                (x.Position == x.Position && filterOptions.Position == null)) &&
                                (x.Salary >= filterOptions.min) &&
                                (x.Salary <= filterOptions.max)
                                )
                            .OrderBy(x => x.Position)
                            .Skip((pageOptions.PageNumber - 1) * pageOptions.PageSize)
                            .Take(pageOptions.PageSize)
                            .ToListAsync();
                    }
                    else
                    {
                        return await _context.Employees
                            .Where(x =>
                                ((x.Fullname == filterOptions.EmployeeName && filterOptions.EmployeeName != null)
                                || (x.Fullname == x.Fullname && filterOptions.EmployeeName == null)) &&
                                ((x.Position == filterOptions.Position && filterOptions.Position != null) ||
                                (x.Position == x.Position && filterOptions.Position == null)) &&
                                (x.Salary >= filterOptions.min) &&
                                (x.Salary <= filterOptions.max)
                                )
                             .OrderByDescending(x => x.Position)
                             .Skip((pageOptions.PageNumber - 1) * pageOptions.PageSize)
                             .Take(pageOptions.PageSize)
                             .ToListAsync();
                    }
                case "Salary":
                    if (pageOptions.SortingDirection == "Ascending")
                    {
                        return await _context.Employees
                            .Where(x =>
                                ((x.Fullname == filterOptions.EmployeeName && filterOptions.EmployeeName != null)
                                || (x.Fullname == x.Fullname && filterOptions.EmployeeName == null)) &&
                                ((x.Position == filterOptions.Position && filterOptions.Position != null) ||
                                (x.Position == x.Position && filterOptions.Position == null)) &&
                                (x.Salary >= filterOptions.min) &&
                                (x.Salary <= filterOptions.max)
                                )
                            .OrderBy(x => x.Salary)
                            .Skip((pageOptions.PageNumber - 1) * pageOptions.PageSize)
                            .Take(pageOptions.PageSize)
                            .ToListAsync();
                    }
                    else
                    {
                        return await _context.Employees
                            .Where(x =>
                                ((x.Fullname == filterOptions.EmployeeName && filterOptions.EmployeeName != null)
                                || (x.Fullname == x.Fullname && filterOptions.EmployeeName == null)) &&
                                ((x.Position == filterOptions.Position && filterOptions.Position != null) ||
                                (x.Position == x.Position && filterOptions.Position == null)) &&
                                (x.Salary >= filterOptions.min) &&
                                (x.Salary <= filterOptions.max)
                                )
                            .OrderByDescending(x => x.Salary)
                            .Skip((pageOptions.PageNumber - 1) * pageOptions.PageSize)
                            .Take(pageOptions.PageSize)
                            .ToListAsync();
                    }
                case "Date of Employment":
                    if (pageOptions.SortingDirection == "Ascending")
                    {
                        return await _context.Employees
                            .Where(x =>
                                ((x.Fullname == filterOptions.EmployeeName && filterOptions.EmployeeName != null)
                                || (x.Fullname == x.Fullname && filterOptions.EmployeeName == null)) &&
                                ((x.Position == filterOptions.Position && filterOptions.Position != null) ||
                                (x.Position == x.Position && filterOptions.Position == null)) &&
                                (x.Salary >= filterOptions.min) &&
                                (x.Salary <= filterOptions.max)
                                )
                            .OrderBy(x => x.DateOfEmployment)
                            .Skip((pageOptions.PageNumber - 1) * pageOptions.PageSize)
                            .Take(pageOptions.PageSize)
                            .ToListAsync();
                    }
                    else
                    {
                        return await _context.Employees
                            .Where(x =>
                                ((x.Fullname == filterOptions.EmployeeName && filterOptions.EmployeeName != null)
                                || (x.Fullname == x.Fullname && filterOptions.EmployeeName == null)) &&
                                ((x.Position == filterOptions.Position && filterOptions.Position != null) ||
                                (x.Position == x.Position && filterOptions.Position == null)) &&
                                (x.Salary >= filterOptions.min) &&
                                (x.Salary <= filterOptions.max)
                                )
                            .OrderByDescending(x => x.DateOfEmployment)
                            .Skip((pageOptions.PageNumber - 1) * pageOptions.PageSize)
                            .Take(pageOptions.PageSize)
                            .ToListAsync();
                    }
                default:
                    break;
            }

            return await _context.Employees
                            .Where(x =>
                                ((x.Fullname == filterOptions.EmployeeName && filterOptions.EmployeeName != null)
                                || (x.Fullname == x.Fullname && filterOptions.EmployeeName == null)) &&
                                ((x.Position == filterOptions.Position && filterOptions.Position != null) ||
                                (x.Position == x.Position && filterOptions.Position == null)) &&
                                (x.Salary >= filterOptions.min) &&
                                (x.Salary <= filterOptions.max)
                                )
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

        public void Update(Employee employee)
        {
            _context.Employees.Update(employee);
        }

        public void Delete(Employee employee)
        {
            _context.Employees.Remove(employee);
        }

        public async Task<int> GetMaxSalary()
        {
            return await _context.Employees.MaxAsync(x => x.Salary);
        }
        public async Task<int> GetMinSalary()
        {
            return await _context.Employees.MinAsync(x => x.Salary);
        }

        public void Save()
        {
            _context.SaveChangesAsync();
        }
    }
}
