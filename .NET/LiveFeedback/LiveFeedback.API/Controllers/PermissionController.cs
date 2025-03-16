//using LiveFeedback.Core.Entities;
//using Microsoft.AspNetCore.Mvc;
//using LiveFeedback.Services;
//using System.Collections.Generic;
//using System.Threading.Tasks;
//using LiveFeedback.Core.Interfaces.IServices;


//namespace LiveFeedback.API.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class PermissionController : ControllerBase
//    {
//        private readonly IPermissionService _permissionService;

//        public PermissionController(IPermissionService permissionService)
//        {
//            _permissionService = permissionService;
//        }

//        [HttpGet]
//        public async Task<ActionResult<IEnumerable<Permission>>> GetPermissions()
//        {
//            var permissions = await _permissionService.GetAllPermissionsAsync();
//            return Ok(permissions);
//        }

//        [HttpGet("{id}")]
//        public async Task<ActionResult<Permission>> GetPermission(int id)
//        {
//            var permission = await _permissionService.GetPermissionByIdAsync(id);
//            if (permission == null) return NotFound();
//            return Ok(permission);
//        }

//        [HttpPost]
//        public async Task<ActionResult> AddPermission(Permission permission)
//        {
//            await _permissionService.AddPermissionAsync(permission);
//            return CreatedAtAction(nameof(GetPermission), new { id = permission.Id }, permission);
//        }

//        [HttpPut("{id}")]
//        public async Task<ActionResult> UpdatePermission(int id, Permission permission)
//        {
//            if (id != permission.Id) return BadRequest();
//            await _permissionService.UpdatePermissionAsync(permission);
//            return NoContent();
//        }

//        [HttpDelete("{id}")]
//        public async Task<ActionResult> DeletePermission(int id)
//        {
//            await _permissionService.DeletePermissionAsync(id);
//            return NoContent();
//        }

//        // פונקציות מיוחדות
//        [HttpGet("byname/{name}")]
//        public async Task<ActionResult<IEnumerable<Permission>>> GetPermissionsByName(string name)
//        {
//            var permissions = await _permissionService.GetPermissionsByNameAsync(name);
//            return Ok(permissions);
//        }

//        [HttpGet("bydescription/{description}")]
//        public async Task<ActionResult<IEnumerable<Permission>>> GetPermissionsByDescription(string description)
//        {
//            var permissions = await _permissionService.GetPermissionsByDescriptionAsync(description);
//            return Ok(permissions);
//        }
//    }
//}

using AutoMapper;
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
    public class PermissionController : ControllerBase
    {
        private readonly IPermissionService _permissionService;
        private readonly IMapper _mapper;

        public PermissionController(IPermissionService permissionService, IMapper mapper)
        {
            _permissionService = permissionService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PermissionDTO>>> GetPermissions()
        {
            var permissions = await _permissionService.GetAllPermissionsAsync();
            return Ok(permissions);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PermissionDTO>> GetPermission(int id)
        {
            var permission = await _permissionService.GetPermissionByIdAsync(id);
            if (permission == null) return NotFound();
            return Ok(permission);
        }

        [HttpPost]
        public async Task<ActionResult<PermissionDTO>> AddPermission([FromBody] PermissionPostModel permissionPostModel)
        {
            var permissionDto = _mapper.Map<PermissionDTO>(permissionPostModel);
            permissionDto = await _permissionService.AddPermissionAsync(permissionDto);
            if (permissionDto == null) return BadRequest();
            return CreatedAtAction(nameof(GetPermission), new { id = permissionDto.Id }, permissionDto);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<PermissionDTO>> UpdatePermission(int id, [FromBody] PermissionPostModel permissionPostModel)
        {
            var permissionDto = _mapper.Map<PermissionDTO>(permissionPostModel);
            permissionDto = await _permissionService.UpdatePermissionAsync(id, permissionDto);
            if (permissionDto == null) return NotFound();
            return Ok(permissionDto);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> DeletePermission(int id)
        {
            var result = await _permissionService.DeletePermissionAsync(id);
            if (!result) return NotFound();
            return Ok(result);
        }

        [HttpGet("name/{name}")]
        public async Task<ActionResult<IEnumerable<PermissionDTO>>> GetPermissionsByName(string name)
        {
            var permissions = await _permissionService.GetPermissionsByNameAsync(name);
            return Ok(permissions);
        }

        [HttpGet("description/{description}")]
        public async Task<ActionResult<IEnumerable<PermissionDTO>>> GetPermissionsByDescription(string description)
        {
            var permissions = await _permissionService.GetPermissionsByDescriptionAsync(description);
            return Ok(permissions);
        }
    }
}

//using LiveFeedback.Core.DTOs;
//using LiveFeedback.API.PostModels;
//using LiveFeedback.Core.Interfaces.IServices;
//using Microsoft.AspNetCore.Mvc;
//using System.Collections.Generic;
//using System.Threading.Tasks;

//namespace LiveFeedback.API.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class PermissionController : ControllerBase
//    {
//        private readonly IPermissionService _permissionService;

//        public PermissionController(IPermissionService permissionService)
//        {
//            _permissionService = permissionService;
//        }

//        [HttpGet]
//        public async Task<ActionResult<IEnumerable<PermissionDTO>>> GetPermissions()
//        {
//            return Ok(await _permissionService.GetAllPermissionsAsync());
//        }

//        [HttpGet("{id}")]
//        public async Task<ActionResult<PermissionDTO>> GetPermission(int id)
//        {
//            var permission = await _permissionService.GetPermissionByIdAsync(id);
//            if (permission == null) return NotFound();
//            return Ok(permission);
//        }

//        [HttpPost]
//        public async Task<ActionResult<PermissionDTO>> AddPermission(PermissionPostModel model)
//        {
//            var newPermission = await _permissionService.AddPermissionAsync(model);
//            return CreatedAtAction(nameof(GetPermission), new { id = newPermission.Id }, newPermission);
//        }

//        [HttpPut("{id}")]
//        public async Task<ActionResult<PermissionDTO>> UpdatePermission(int id, PermissionPostModel model)
//        {
//            var updatedPermission = await _permissionService.UpdatePermissionAsync(id, model);
//            if (updatedPermission == null) return NotFound();
//            return Ok(updatedPermission);
//        }

//        [HttpDelete("{id}")]
//        public async Task<ActionResult<PermissionDTO>> DeletePermission(int id)
//        {
//            var deletedPermission = await _permissionService.DeletePermissionAsync(id);
//            if (deletedPermission == null) return NotFound();
//            return Ok(deletedPermission);
//        }
//    }
//}
