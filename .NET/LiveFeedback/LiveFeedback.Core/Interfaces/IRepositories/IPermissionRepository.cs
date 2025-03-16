//using LiveFeedback.Core.Entities;
//using System.Collections.Generic;
//using System.Threading.Tasks;

//namespace LiveFeedback.Core.Interfaces.IRepositories

//{
//    public interface IPermissionRepository : IRepository<Permission>
//    {
//        Task<IEnumerable<Permission>> GetPermissionsByNameAsync(string name);
//        Task<IEnumerable<Permission>> GetPermissionsByDescriptionAsync(string description);
//    }
//}
using LiveFeedback.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LiveFeedback.Core.Interfaces.IRepositories
{
    public interface IPermissionRepository : IRepository<Permission>
    {
        Task<IEnumerable<Permission>> GetPermissionsByNameAsync(string name);
        Task<IEnumerable<Permission>> GetPermissionsByDescriptionAsync(string description);
    }
}

