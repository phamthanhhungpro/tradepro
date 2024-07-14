using tradepro.InfraModel.DataAccess;
using tradepro.Logic.Interfaces;
using tradepro.Logic.Request;
using Microsoft.EntityFrameworkCore;
using tradepro.Logic.DTOs;
namespace tradepro.Logic.Services
{
    public class RoleService : IRoleService
    {
        private readonly TradeproDbContext _context;
        public RoleService(TradeproDbContext context)
        {
            _context = context;
        }
        public void CreateRole(RoleRequest roleRequest)
        {
            var newRole = new Role()
            {
                Code = roleRequest.Code,
                Name = roleRequest.Name,
                Description = roleRequest.Description,
            };

            newRole.CreatedAt = DateTime.UtcNow;

            _context.Roles.Add(newRole);
            _context.SaveChanges();

        }

        public async Task<IEnumerable<RoleSelectList>> FilterRole()
        {
            return await _context.Roles.Where(x=> !x.Code.Equals("SU")).Select(x=> new RoleSelectList
            {
                RoleId = x.Id,
                RoleName = x.Name
            }).ToListAsync();
        }

        public async Task<Role> GetRoleById(Guid Id)
        {
            return await _context.Roles.FirstAsync(x => x.Id == Id);
        }

        public async  Task<IEnumerable<Role>> GetRoles()
        {
             return await  _context.Roles.ToListAsync();

        }
    }
}
