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
    public class RoleController : ControllerBase
    {

        private readonly IRoleService _roleService;
        public RoleController( IRoleService roleService ) 
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
        [HttpGet("/get-role-by-id")]
        public async Task<Role> GetRoleById(Guid id)
        {

            return await _roleService.GetRoleById(id);
        }
        [HttpGet("/filter-role")]
        public async Task<IEnumerable<RoleSelectList>> FilterRole()
        {
            return await _roleService.FilterRole();
        }

    }
}
