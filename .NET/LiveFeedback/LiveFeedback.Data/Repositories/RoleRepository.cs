//using LiveFeedback.Core.Entities;
//using Microsoft.EntityFrameworkCore;
//using System.Collections.Generic;
//using System.Threading.Tasks;
//using LiveFeedback.Core.Interfaces.IRepositories;


//namespace LiveFeedback.Data.Repositories
//{
//    public class RoleRepository : Repository<Role>, IRoleRepository
//    {
//        public RoleRepository(DataContext context) : base(context) { }

//        // פונקציה מיוחדת לקבלת תפקידי משתמשים עם ההרשאות
//        public async Task<IEnumerable<Role>> GetRolesWithPermissionsAsync()
//        {
//            return await _context.Roles
//                .Include(r => r.Permissions)
//                .ToListAsync();
//        }

//        // פונקציה מיוחדת לקבלת תפקיד לפי שם
//        public async Task<Role> GetRoleByNameAsync(string roleName)
//        {
//            return await _context.Roles
//                .FirstOrDefaultAsync(r => r.RoleName == roleName);
//        }
//    }
//}
using LiveFeedback.Core.Entities;
using LiveFeedback.Core.Interfaces.IRepositories;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LiveFeedback.Data.Repositories
{
    public class RoleRepository : Repository<Role>, IRoleRepository
    {
        public RoleRepository(DataContext context) : base(context) { }

        public async Task<IEnumerable<Role>> GetRolesWithPermissionsAsync()
        {
            return await _context.Roles
                .Include(r => r.Permissions)
                .ToListAsync();
        }

        public async Task<Role> GetRoleByNameAsync(string roleName)
        {
            return await _context.Roles
                .FirstOrDefaultAsync(r => r.RoleName == roleName);
        }
    }
}

