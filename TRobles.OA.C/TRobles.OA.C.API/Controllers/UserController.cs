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
        public async Task<IEnumerable<User>> Get()
        {
           return await _userService.Get();
        }
        [HttpPost]
        [Route("create")]
        public  Task<bool> Create(User user)
        {
            user.Birthdate = DateTime.Now;
            user.TransactionDate = DateTime.Now;
            
            return _userService.Insert(user);
        }

        [HttpPost]
        [Route("edit")]
        public void Update(User user)
        {
            //var user = _userService.Get(id).Result;
            if(user != null)
            {
                _userService.Update(user);
            }
        }
    }
}
