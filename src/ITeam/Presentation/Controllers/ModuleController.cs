using ITeam.Application.Services.Exceptions.NotFoundExceptions;
using ITeam.Application.Services.Modules;
using ITeam.Presentation.DTOs;
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
            catch (NotFoundException ex)
            {
                return NotFound(ex);
            }
        }

        [HttpPut("{moduleId}")]
        public async Task<ActionResult> UpdateModule(ModuleDto module)
        {
            try
            {
                await _moduleService.UpdateModuleDescriptionAsync(module);
                return NoContent();
            }
            catch (NotFoundException ex)
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
            catch (NotFoundException ex)
            {
                return NotFound(ex);
            }
        }
    }
}
