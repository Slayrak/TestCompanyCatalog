﻿using CompanyCatalogue.Models;

namespace CompanyCatalogue.Interfaces
{
    public interface IEmployeeRepository
    {
        Task<Employee> GetByIdAsync(int id);

        Task<IEnumerable<Employee>> GetAll();

        Task<Employee> GetTree(int id);
        Task<Employee> GetTree(Employee employee);

        Task Add(Employee employee);
        void Update(Employee employee);
        void Delete(Employee employee);
        void Save();
    }
}