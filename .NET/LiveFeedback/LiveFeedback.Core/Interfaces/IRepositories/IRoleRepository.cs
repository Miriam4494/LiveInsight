//using LiveFeedback.Core.Entities;
//using System.Collections.Generic;
//using System.Threading.Tasks;

//namespace LiveFeedback.Core.Interfaces.IRepositories
//{
//    public interface IRoleRepository : IRepository<Role>
//    {
//        Task<IEnumerable<Role>> GetRolesWithPermissionsAsync();
//        Task<Role> GetRoleByNameAsync(string roleName);
//    }
//}
using LiveFeedback.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LiveFeedback.Core.Interfaces.IRepositories
{
    public interface IRoleRepository : IRepository<Role>
    {
        Task<IEnumerable<Role>> GetRolesWithPermissionsAsync();
        Task<Role> GetRoleByNameAsync(string roleName);
    }
}
