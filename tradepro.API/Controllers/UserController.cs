using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using tradepro.InfraModel.DataAccess;
using tradepro.Logic.Interfaces;
using tradepro.Logic.Request;

namespace tradepro.API.Controllers
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

        [HttpGet("/list-user")] 
        public async Task<List<User>> getListUser()
        {
            return await _userService.ListUser();
        }

        [HttpPost] 
        public async void AddUser ([FromBody] UserRequest userRequest)
        {
            _userService.CreateUser(userRequest);
        }
    }
}
