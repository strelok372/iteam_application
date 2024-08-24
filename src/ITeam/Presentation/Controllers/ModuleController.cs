using ITeam.Application.DTOs;
using ITeam.Application.Services.Excaptions;
using ITeam.Application.Services.Modules;
using Microsoft.AspNetCore.Mvc;

namespace ITeam.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ModuleController : ControllerBase
    {
        private readonly IModuleService _moduleService;

        public ModuleController(IModuleService moduleService) => _moduleService = moduleService;

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ModuleDto>>> GetAllModulesAsync() => Ok(await _moduleService.GetAllModulesAsync());

        [HttpGet("{moduleId}")]
        public async Task<ActionResult<ModuleDto>> GetModuleAsync(int moduleId)
        {
            return await _moduleService.GetModuleAsync(moduleId);
        }

        [HttpPost]
        public async Task<ActionResult<ModuleDto>> AddModuleAsync(ModuleDto module)
        {
            try
            {
                return CreatedAtAction(nameof(GetModuleAsync), await _moduleService.AddModuleAsync(module));
            }
            catch (NotFoundExeption ex)
            {
                return NotFound(ex);
            }
        }

        [HttpPatch("{moduleId}/Description")]
        public async Task<ActionResult> UpdateModuleDescription(int moduleId, string description)
        {
            try
            {
                await _moduleService.UpdateModuleDescriptionAsync(moduleId, description);
                return NoContent();
            }
            catch (NotFoundExeption ex)
            {
                return NotFound(ex);
            }
        }

        [HttpPatch("{moduleId}/ModuleType")]
        public async Task<ActionResult> UpdateModuleType(int moduleId, int moduleTypeId)
        {
            try
            {
                await _moduleService.UpdateModuleTypeAsync(moduleId, moduleTypeId);
                return NoContent();
            }
            catch (NotFoundExeption ex)
            {
                return NotFound(ex);
            }
        }

        [HttpDelete("{moduleId}")]
        public async Task<ActionResult> DeleteService(int moduleId)
        {
            try
            {
                await _moduleService.DeleteModuleAsync(moduleId);
                return NoContent();
            }
            catch (NotFoundExeption ex)
            {
                return NotFound(ex);
            }
        }
    }
}
