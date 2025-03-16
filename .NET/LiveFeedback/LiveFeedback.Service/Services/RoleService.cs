//using LiveFeedback.Core.Entities;

//using System.Collections.Generic;
//using System.Threading.Tasks;
//using LiveFeedback.Core.Interfaces.IRepositories;
//using LiveFeedback.Core.Interfaces.IServices;

//namespace LiveFeedback.Services.Services
//{
//    public class RoleService : IRoleService
//    {
//        private readonly IRoleRepository _roleRepository;

//        public RoleService(IRoleRepository roleRepository)
//        {
//            _roleRepository = roleRepository;
//        }

//        public async Task<IEnumerable<Role>> GetAllRolesAsync()
//        {
//            return await _roleRepository.GetAllAsync();
//        }

//        public async Task<Role> GetRoleByIdAsync(int id)
//        {
//            return await _roleRepository.GetByIdAsync(id);
//        }

//        public async Task AddRoleAsync(Role role)
//        {
//            await _roleRepository.AddAsync(role);
//        }

//        public async Task UpdateRoleAsync(Role role)
//        {
//            await _roleRepository.UpdateAsync(role);
//        }

//        public async Task DeleteRoleAsync(int id)
//        {
//            await _roleRepository.DeleteAsync(id);
//        }

//        public async Task<IEnumerable<Role>> GetRolesWithPermissionsAsync()
//        {
//            return await _roleRepository.GetRolesWithPermissionsAsync();
//        }

//        public async Task<Role> GetRoleByNameAsync(string roleName)
//        {
//            return await _roleRepository.GetRoleByNameAsync(roleName);
//        }
//    }
//}
using LiveFeedback.Core.DTOs;
using LiveFeedback.Core.Entities;
using LiveFeedback.Core.Interfaces.IRepositories;
using LiveFeedback.Core.Interfaces.IServices;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LiveFeedback.Services.Services
{
    public class RoleService : IRoleService
    {
        private readonly IRoleRepository _roleRepository;
        private readonly IMapper _mapper;

        public RoleService(IRoleRepository roleRepository, IMapper mapper)
        {
            _roleRepository = roleRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<RoleDTO>> GetAllRolesAsync()
        {
            var roles = await _roleRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<RoleDTO>>(roles);
        }

        public async Task<RoleDTO> GetRoleByIdAsync(int id)
        {
            var role = await _roleRepository.GetByIdAsync(id);
            return _mapper.Map<RoleDTO>(role);
        }

        public async Task<RoleDTO> AddRoleAsync(RoleDTO roleDto)
        {
            var role = _mapper.Map<Role>(roleDto);
            await _roleRepository.AddAsync(role);
            return _mapper.Map<RoleDTO>(role);
        }

      
        public async Task<RoleDTO> UpdateRoleAsync(int id, RoleDTO roleDto)
        {
            // מציאת התמונה לפי ה-ID בלבד
            var role = await _roleRepository.GetByIdAsync(id);
            if (role == null) return null;

            // ממפים את ה-DTO ל-Entity (MyImage), אבל לא משפיעים על ה-ID
            Role entity = _mapper.Map<Role>(roleDto);

            // עושים Save רק לאחר המיפוי, לא מעדכנים את ה-ID
            await _roleRepository.UpdateAsync(id, entity);  // אל תעביר את ה-ID כאן

            return _mapper.Map<RoleDTO>(entity);
        }

        public async Task<bool> DeleteRoleAsync(int id)
        {
            var role = await _roleRepository.GetByIdAsync(id);
            if (role == null) return false;

            await _roleRepository.DeleteAsync(id);
            return true;
        }

        public async Task<IEnumerable<RoleDTO>> GetRolesWithPermissionsAsync()
        {
            var roles = await _roleRepository.GetRolesWithPermissionsAsync();
            return _mapper.Map<IEnumerable<RoleDTO>>(roles);
        }

        public async Task<RoleDTO> GetRoleByNameAsync(string roleName)
        {
            var role = await _roleRepository.GetRoleByNameAsync(roleName);
            return _mapper.Map<RoleDTO>(role);
        }
    }

}

