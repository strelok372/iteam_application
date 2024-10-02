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
        [ActionName(nameof(GetModuleAsync))]
        public async Task<ActionResult<ModuleDto>> GetModuleAsync(int moduleId)
        {
            try
            {
                return await _moduleService.GetModuleAsync(moduleId);
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult<ModuleDto>> AddModuleAsync(ModuleDto module)
        {
            try
            {
                var newModule = await _moduleService.AddModuleAsync(module);
                return CreatedAtAction(nameof(GetModuleAsync), new { moduleId = newModule.Id }, newModule);
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public async Task<ActionResult> UpdateModule(ModuleDto module)
        {
            try
            {
                await _moduleService.UpdateModuleAsync(module);
                return NoContent();
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
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
                return NotFound(ex.Message);
            }
        }
    }
}
