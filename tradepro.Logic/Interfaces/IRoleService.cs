using tradepro.InfraModel.DataAccess;
using tradepro.Logic.Request;

namespace tradepro.Logic.Interfaces
{
    public interface IRoleService
    {
        void CreateRole(RoleRequest roleRequest);
        Task<IEnumerable<Role>> GetRoles();
    }
}
