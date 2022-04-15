using Core.Entities;
using Core.Interfaces;
using Infrastructure.DBContext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class RepositoryService : IRepository
    {
        private readonly ApplicationDbContext db;
        public RepositoryService(ApplicationDbContext db)
        {
            this.db = db;
        }
        public async Task<List<Employee>> GetAll()
        {
            return await db.Employees.ToListAsync();
        }

        public async Task<Employee> GetById(int id)
        {
            return await db.Employees.FindAsync(id);
        }
        public async Task<Employee> CreateAsync(string name, string role, string email, string contact, string domain)
        {
            Employee employee = new Employee(name, role, email, contact, domain);
            db.Employees.Add(employee);
            await db.SaveChangesAsync();
            return employee;
        }


    }
}
