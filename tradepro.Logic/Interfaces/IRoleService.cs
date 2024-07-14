using tradepro.InfraModel.DataAccess;
using tradepro.Logic.DTOs;
using tradepro.Logic.Request;

namespace tradepro.Logic.Interfaces
{
    public interface IRoleService
    {
        void CreateRole(RoleRequest roleRequest);
        Task<IEnumerable<Role>> GetRoles();
        Task<Role> GetRoleById(Guid Id);
        Task<IEnumerable<RoleSelectList>> FilterRole();
    }
}
