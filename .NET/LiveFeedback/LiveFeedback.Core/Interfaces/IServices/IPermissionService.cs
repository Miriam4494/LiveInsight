//using LiveFeedback.Core.Entities;
//using System.Collections.Generic;
//using System.Threading.Tasks;


//namespace LiveFeedback.Core.Interfaces.IServices
//{
//    public interface IPermissionService
//    {
//        Task<IEnumerable<Permission>> GetAllPermissionsAsync();
//        Task<Permission> GetPermissionByIdAsync(int id);
//        Task AddPermissionAsync(Permission permission);
//        Task UpdatePermissionAsync(Permission permission);
//        Task DeletePermissionAsync(int id);

//        // פונקציות מיוחדות
//        Task<IEnumerable<Permission>> GetPermissionsByNameAsync(string name);
//        Task<IEnumerable<Permission>> GetPermissionsByDescriptionAsync(string description);
//    }
//}
using LiveFeedback.Core.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LiveFeedback.Core.Interfaces.IServices
{
    public interface IPermissionService
    {
        Task<IEnumerable<PermissionDTO>> GetAllPermissionsAsync();
        Task<PermissionDTO> GetPermissionByIdAsync(int id);
        Task<PermissionDTO> AddPermissionAsync(PermissionDTO permissionDto);
        Task<PermissionDTO> UpdatePermissionAsync(int id, PermissionDTO permissionDto);
        Task<bool> DeletePermissionAsync(int id);
        Task<IEnumerable<PermissionDTO>> GetPermissionsByNameAsync(string name);
        Task<IEnumerable<PermissionDTO>> GetPermissionsByDescriptionAsync(string description);
    }
}
