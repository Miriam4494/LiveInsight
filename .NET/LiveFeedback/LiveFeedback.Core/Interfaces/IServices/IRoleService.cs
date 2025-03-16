//using LiveFeedback.Core.Entities;
//using System.Collections.Generic;
//using System.Threading.Tasks;


//namespace LiveFeedback.Core.Interfaces.IServices
//{
//    public interface IRoleService
//    {
//        Task<IEnumerable<Role>> GetAllRolesAsync();
//        Task<Role> GetRoleByIdAsync(int id);
//        Task AddRoleAsync(Role role);
//        Task UpdateRoleAsync(Role role);
//        Task DeleteRoleAsync(int id);
//        Task<IEnumerable<Role>> GetRolesWithPermissionsAsync();
//        Task<Role> GetRoleByNameAsync(string roleName);
//    }
//}
using LiveFeedback.Core.DTOs;
using LiveFeedback.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LiveFeedback.Core.Interfaces.IServices
{
    public interface IRoleService
    {
        Task<IEnumerable<RoleDTO>> GetAllRolesAsync();
        Task<RoleDTO> GetRoleByIdAsync(int id);
        Task<RoleDTO> AddRoleAsync(RoleDTO roleDto);
        Task<RoleDTO> UpdateRoleAsync(int id, RoleDTO roleDto);
        Task<bool> DeleteRoleAsync(int id);
        Task<IEnumerable<RoleDTO>> GetRolesWithPermissionsAsync();
        Task<RoleDTO> GetRoleByNameAsync(string roleName);
    }

}

