using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TRobles.OA.C.Entities;
using TRobles.OA.C.Service;

namespace TRobles.OA.C.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly IRoleService _roleService;
        public RoleController(IRoleService roleService)
        {
            _roleService = roleService;
        }

        [HttpGet]
        [Route("get")]
        public async Task<IEnumerable<Role>> Get()
        {
            return await _roleService.Get();
        }
        [HttpPost]
        [Route("create")]
        public Task<bool> Create(Role role)
        {
            //user.Birthdate = DateTime.Now;
            role.TransactionDate = DateTime.Now;

            return _roleService.Insert(role);
        }

        [HttpPost]
        [Route("edit")]
        public void Update(Role role)
        {

            if (role != null)
            {
                _roleService.Update(role);
            }
        }
    }
}
