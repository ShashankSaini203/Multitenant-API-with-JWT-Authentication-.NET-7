using Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IRepository
    {
        public Task<List<Employee>> GetAll();
        public Task<Employee> GetById(int id);
        public Task<Employee> CreateAsync(string name, string role, string email, string contact, string domain);

    }
}
