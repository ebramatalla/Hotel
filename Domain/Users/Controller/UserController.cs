using Hotel.Domain.Users.Model;
using Hotel.Domain.Users.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.RegularExpressions;

namespace Hotel.Domain.Users.Controller
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
        [HttpPost]
        [Route("CreateUser")]
        public async void AddUser(User user)
        {
          await _userService.CreateUser(user);

        }
        [HttpGet]
        [Route("GetByID")]
        public async Task<IActionResult> GetUser(string userId)
        {
            var user=  await _userService.GetById(userId);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);

        }


    }
}
