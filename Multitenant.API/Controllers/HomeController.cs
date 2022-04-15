using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Multitenant.API.Controllers
{
    
    public class HomeController : ControllerBase
    {
        private readonly IRepository repo;
        public HomeController(IRepository repo)
        {
            this.repo = repo;
        }

        [Route("api/GetAll")]
        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetAllEmoployees()
        {
            return Ok(await repo.GetAll());
        }

        [Route("api/Get/{id}")]
        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await repo.GetById(id));
        }

        [Route("api/Create")]
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Create([FromBody]CreateEmployeeRequest request)
        {
            return Ok(await repo.CreateAsync(request.Name, request.Role, request.Email, request.Contact, request.Domain));
        }

        public class CreateEmployeeRequest
        {
            public string Name { get; set; }
            public string Role { get; set; }
            public string Email { get; set; }
            public string Contact { get; set; }
            public string Domain { get; set; }
        }
    }
}
