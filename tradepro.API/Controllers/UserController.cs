using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using tradepro.InfraModel.DataAccess;
using tradepro.Logic.DTOs;
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

        [HttpPost("/list-user")] 
        public async Task<List<UserInfoDto>> getListUser( )
        {
            return await _userService.ListUser();
        }

        [HttpPost] 
        public async void AddUser ([FromBody] UserRequest userRequest)
        {
            _userService.CreateUser(userRequest);
        }
        [HttpPost("/update-user")]
        public async Task<CudResponseDto> UpdateUser(Guid id,UpdateUserRequest updateUserRequest)
        {
            return await _userService.UpdateUser(id,updateUserRequest);
        }

        [HttpPost("/change-password")]
        public async Task<CudResponseDto> ChangePassword(Guid id,ChangpasswordRequest changpasswordRequest)
        {
            return await _userService.ChangePassword(id,changpasswordRequest);
        }

        [HttpGet("/get-user-by-email")]
        public async Task<User> GetUserByEmail(string email)
        {
            return await _userService.GetUserByEmail(email);
        }
    }
}
