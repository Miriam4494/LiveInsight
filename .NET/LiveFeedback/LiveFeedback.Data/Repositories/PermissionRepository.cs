//using LiveFeedback.Core.Entities;
//using Microsoft.EntityFrameworkCore;
//using System.Collections.Generic;
//using System.Threading.Tasks;
//using LiveFeedback.Core.Interfaces.IRepositories;


//namespace LiveFeedback.Data.Repositories
//{
//    public class PermissionRepository : Repository<Permission>, IPermissionRepository
//    {
//        public PermissionRepository(DataContext context) : base(context) { }

//        // פונקציה מיוחדת לחיפוש הרשאות לפי שם
//        public async Task<IEnumerable<Permission>> GetPermissionsByNameAsync(string name)
//        {
//            return await _context.Permissions
//                .Where(p => p.PermissionName.Contains(name))
//                .ToListAsync();
//        }

//        // פונקציה מיוחדת לחיפוש הרשאות לפי תיאור
//        public async Task<IEnumerable<Permission>> GetPermissionsByDescriptionAsync(string description)
//        {
//            return await _context.Permissions
//                .Where(p => p.Description.Contains(description))
//                .ToListAsync();
//        }
//    }
//}
using LiveFeedback.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LiveFeedback.Core.Interfaces.IRepositories;

namespace LiveFeedback.Data.Repositories
{
    public class PermissionRepository : Repository<Permission>, IPermissionRepository
    {
        public PermissionRepository(DataContext context) : base(context) { }

        public async Task<IEnumerable<Permission>> GetPermissionsByNameAsync(string name)
        {
            return await _context.Permissions
                .Where(p => p.PermissionName.Contains(name))
                .ToListAsync();
        }

        public async Task<IEnumerable<Permission>> GetPermissionsByDescriptionAsync(string description)
        {
            return await _context.Permissions
                .Where(p => p.Description.Contains(description))
                .ToListAsync();
        }
    }
}
