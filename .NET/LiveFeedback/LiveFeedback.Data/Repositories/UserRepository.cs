//using LiveFeedback.Core.Entities;
//using Microsoft.EntityFrameworkCore;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using LiveFeedback.Core.Interfaces.IRepositories;


//namespace LiveFeedback.Data.Repositories
//{
//    public class UserRepository : Repository<User>, IUserRepository
//    {
//        public UserRepository(DataContext context) : base(context) { }

//        public async Task<IEnumerable<User>> GetUsersWithDetailsAsync()
//        {
//            return await _context.Users
//                .Include(u => u.Questions)
//                .Include(u => u.UserRoles)
//                .ToListAsync();
//        }
//    }
//}
using LiveFeedback.Core.Entities;
using LiveFeedback.Core.Interfaces.IRepositories;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using LiveFeedback.Core.DTOs;

namespace LiveFeedback.Data.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        private readonly IMapper _mapper;

        public UserRepository(DataContext context, IMapper mapper) : base(context)
        {
            _mapper = mapper;
        }

        public async Task<IEnumerable<UserDTO>> GetUsersWithDetailsAsync()
        {
            var users = await _context.Users
                .Include(u => u.Questions)
                .Include(u => u.UserRoles)
                .ToListAsync();

            return _mapper.Map<IEnumerable<UserDTO>>(users);
        }

        public async Task<UserDTO> GetUserByIdAsync(int id)
        {
            var user = await _context.Users
                .Include(u => u.Questions)
                .Include(u => u.UserRoles)
                .FirstOrDefaultAsync(u => u.Id == id);

            return user == null ? null : _mapper.Map<UserDTO>(user);
        }

        public async Task<User> GetUserByEmailAsync(string email)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
        }

    }
}
