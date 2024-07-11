using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using tradepro.Logic.Interfaces;
using tradepro.Logic.Request;
namespace tradepro.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenicationController : ControllerBase
    {
        private readonly IAuthService _authService;
        public AuthenicationController(IAuthService authService)
        {
            _authService = authService;
        }

     }
}
