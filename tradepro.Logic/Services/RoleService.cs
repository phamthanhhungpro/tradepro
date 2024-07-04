using tradepro.InfraModel.DataAccess;
using tradepro.Logic.Interfaces;
using tradepro.Logic.Request;
using Microsoft.EntityFrameworkCore;
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

        public async  Task<IEnumerable<Role>> GetRoles()
        {
             return await  _context.Roles.ToListAsync();

        }
    }
}
