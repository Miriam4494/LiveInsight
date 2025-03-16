﻿//using LiveFeedback.Core.Entities;

//using System.Collections.Generic;
//using System.Threading.Tasks;
//using LiveFeedback.Core.Interfaces.IRepositories;
//using LiveFeedback.Core.Interfaces.IServices;

//namespace LiveFeedback.Services.Services
//{
//    public class PermissionService : IPermissionService
//    {
//        private readonly IPermissionRepository _permissionRepository;

//        public PermissionService(IPermissionRepository permissionRepository)
//        {
//            _permissionRepository = permissionRepository;
//        }

//        public async Task<IEnumerable<Permission>> GetAllPermissionsAsync() => await _permissionRepository.GetAllAsync();

//        public async Task<Permission> GetPermissionByIdAsync(int id) => await _permissionRepository.GetByIdAsync(id);

//        public async Task AddPermissionAsync(Permission permission) => await _permissionRepository.AddAsync(permission);

//        public async Task UpdatePermissionAsync(Permission permission) => await _permissionRepository.UpdateAsync(permission);

//        public async Task DeletePermissionAsync(int id) => await _permissionRepository.DeleteAsync(id);

//        // פונקציות מיוחדות
//        public async Task<IEnumerable<Permission>> GetPermissionsByNameAsync(string name) => await _permissionRepository.GetPermissionsByNameAsync(name);

//        public async Task<IEnumerable<Permission>> GetPermissionsByDescriptionAsync(string description) => await _permissionRepository.GetPermissionsByDescriptionAsync(description);
//    }
//}
using AutoMapper;
using LiveFeedback.Core.DTOs;
using LiveFeedback.Core.Entities;
using LiveFeedback.Core.Interfaces.IRepositories;
using LiveFeedback.Core.Interfaces.IServices;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LiveFeedback.Services.Services
{
    public class PermissionService : IPermissionService
    {
        private readonly IPermissionRepository _permissionRepository;
        private readonly IMapper _mapper;

        public PermissionService(IPermissionRepository permissionRepository, IMapper mapper)
        {
            _permissionRepository = permissionRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<PermissionDTO>> GetAllPermissionsAsync()
        {
            var permissions = await _permissionRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<PermissionDTO>>(permissions);
        }

        public async Task<PermissionDTO> GetPermissionByIdAsync(int id)
        {
            var permission = await _permissionRepository.GetByIdAsync(id);
            return _mapper.Map<PermissionDTO>(permission);
        }

        public async Task<PermissionDTO> AddPermissionAsync(PermissionDTO permissionDto)
        {
            var permission = _mapper.Map<Permission>(permissionDto);
            await _permissionRepository.AddAsync(permission);
            return _mapper.Map<PermissionDTO>(permission);
        }

      
        public async Task<PermissionDTO> UpdatePermissionAsync(int id, PermissionDTO permissionDto)
        {
            // מציאת התמונה לפי ה-ID בלבד
            var permission = await _permissionRepository.GetByIdAsync(id);
            if (permission == null) return null;

            // ממפים את ה-DTO ל-Entity (MyImage), אבל לא משפיעים על ה-ID
            Permission entity = _mapper.Map<Permission>(permissionDto);

            // עושים Save רק לאחר המיפוי, לא מעדכנים את ה-ID
            await _permissionRepository.UpdateAsync(id, entity);  // אל תעביר את ה-ID כאן

            return _mapper.Map<PermissionDTO>(entity);
        }


        public async Task<bool> DeletePermissionAsync(int id)
        {
            var permission = await _permissionRepository.GetByIdAsync(id);
            if (permission == null) return false;

            await _permissionRepository.DeleteAsync(id);
            return true;
        }

        public async Task<IEnumerable<PermissionDTO>> GetPermissionsByNameAsync(string name)
        {
            var permissions = await _permissionRepository.GetPermissionsByNameAsync(name);
            return _mapper.Map<IEnumerable<PermissionDTO>>(permissions);
        }

        public async Task<IEnumerable<PermissionDTO>> GetPermissionsByDescriptionAsync(string description)
        {
            var permissions = await _permissionRepository.GetPermissionsByDescriptionAsync(description);
            return _mapper.Map<IEnumerable<PermissionDTO>>(permissions);
        }
    }
}
