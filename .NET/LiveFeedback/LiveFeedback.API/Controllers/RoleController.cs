﻿using AutoMapper;
using LiveFeedback.Core.DTOs;
using LiveFeedback.Core.Interfaces.IServices;
using LiveFeedback.API.PostModels;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LiveFeedback.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly IRoleService _roleService;
        private readonly IMapper _mapper;

        public RoleController(IRoleService roleService, IMapper mapper)
        {
            _roleService = roleService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<RoleDTO>>> GetRoles()
        {
            var roles = await _roleService.GetAllRolesAsync();
            return Ok(roles);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<RoleDTO>> GetRole(int id)
        {
            var role = await _roleService.GetRoleByIdAsync(id);
            if (role == null) return NotFound();
            return Ok(role);
        }

        [HttpPost]
        public async Task<ActionResult<RoleDTO>> AddRole([FromBody] RolePostModel rolePostModel)
        {
            var roleDto = _mapper.Map<RoleDTO>(rolePostModel);
            roleDto = await _roleService.AddRoleAsync(roleDto);
            if (roleDto == null) return BadRequest();
            return CreatedAtAction(nameof(GetRole), new { id = roleDto.Id }, roleDto);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<RoleDTO>> UpdateRole(int id, [FromBody] RolePostModel rolePostModel)
        {
            var roleDto = _mapper.Map<RoleDTO>(rolePostModel);
            roleDto = await _roleService.UpdateRoleAsync(id, roleDto);
            if (roleDto == null) return NotFound();
            return Ok(roleDto);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> DeleteRole(int id)
        {
            var result = await _roleService.DeleteRoleAsync(id);
            if (!result) return NotFound();
            return Ok(result);
        }

        [HttpGet("permissions")]
        public async Task<ActionResult<IEnumerable<RoleDTO>>> GetRolesWithPermissions()
        {
            var roles = await _roleService.GetRolesWithPermissionsAsync();
            return Ok(roles);
        }

        [HttpGet("name/{roleName}")]
        public async Task<ActionResult<RoleDTO>> GetRoleByName(string roleName)
        {
            var role = await _roleService.GetRoleByNameAsync(roleName);
            if (role == null) return NotFound();
            return Ok(role);
        }
    }
}


//using LiveFeedback.API.PostModels;
//using LiveFeedback.Core.DTOs;
//using LiveFeedback.Core.Interfaces.IServices;
//using Microsoft.AspNetCore.Mvc;
//using System.Collections.Generic;
//using System.Threading.Tasks;

//namespace LiveFeedback.API.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class RoleController : ControllerBase
//    {
//        private readonly IRoleService _roleService;

//        public RoleController(IRoleService roleService)
//        {
//            _roleService = roleService;
//        }

//        [HttpGet]
//        public async Task<ActionResult<IEnumerable<RoleDTO>>> GetRoles()
//        {
//            return Ok(await _roleService.GetAllRolesAsync());
//        }

//        [HttpGet("{id}")]
//        public async Task<ActionResult<RoleDTO>> GetRole(int id)
//        {
//            var role = await _roleService.GetRoleByIdAsync(id);
//            if (role == null) return NotFound();
//            return Ok(role);
//        }

//        [HttpPost]
//        public async Task<ActionResult<RoleDTO>> AddRole(RolePostModel rolePostModel)
//        {
//            var newRole = await _roleService.AddRoleAsync(rolePostModel);
//            return CreatedAtAction(nameof(GetRole), new { id = newRole.RoleName }, newRole);
//        }

//        [HttpPut("{id}")]
//        public async Task<ActionResult<RoleDTO>> UpdateRole(int id, RolePostModel rolePostModel)
//        {
//            var updatedRole = await _roleService.UpdateRoleAsync(id, rolePostModel);
//            if (updatedRole == null) return NotFound();
//            return Ok(updatedRole);
//        }

//        [HttpDelete("{id}")]
//        public async Task<ActionResult> DeleteRole(int id)
//        {
//            var result = await _roleService.DeleteRoleAsync(id);
//            if (!result) return NotFound();
//            return NoContent();
//        }
//    }
//}
