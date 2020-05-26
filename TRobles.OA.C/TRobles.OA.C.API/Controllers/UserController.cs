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
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        [Route("get")]
        public async Task<IEnumerable<User>> get()
        {
           return await _userService.Get();
        }
        [HttpPost]
        [Route("create")]
        public  Task<bool> create(string email,string userName,string password)
        {
            return _userService.Insert(new User() { Email = email, Password = password, UserName = userName, CreatedById = Guid.NewGuid(), CreatedDate = DateTime.Now });
        }
    }
}
