using Core.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class Employee : BaseEntity, IMustHaveTenant
    {
        public Employee(string name, string role, string email, string contact, string domain)
        {
            Name = name;
            Role = role;
            Email = email;
            Contact = contact;
            Domain = domain;
        }
        protected Employee() { }
        public string Name { get; private set; }
        public string Role { get; private set; }
        public string Email { get; private set; }
        public string Contact { get; private set; }
        public string Domain { get; private set; }
        public int? TenantId { get; set; }
    }
}
