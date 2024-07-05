using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using tradepro.InfraModel.DataAccess;
using tradepro.Logic.Interfaces;
using tradepro.Logic.Request;

namespace tradepro.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {

        private readonly IRoleService _roleService;
        public RoleController(TradeproDbContext context, IRoleService roleService ) 
        { 
            _roleService = roleService;
        }

        [HttpGet("/get-role")] 
        public async Task<IEnumerable<Role>> GetRole() {

            return  await _roleService.GetRoles();
        }
        [HttpPost]
        public void CreateRole(RoleRequest roleRequest)
        {
            _roleService.CreateRole(roleRequest);
        }
    }
}
