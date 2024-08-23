using ITeam.Application.DTOs;
using ITeam.Application.Services;
using ITeam.Application.Services.Exaptions;
using Microsoft.AspNetCore.Mvc;

namespace ITeam.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiceController : ControllerBase
    {
        private readonly IServiceService _serviceService;

        public ServiceController(IServiceService serviceService) => _serviceService = serviceService;

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ServiceDto>>> GetAllServicesAsync() => Ok(await _serviceService.GetAllServicesAsync());

        [HttpGet("{serviceId}")]
        public async Task<ActionResult<ServiceDto>> GetServicesAsync(int serviceId)
        {
            return await _serviceService.GetServiceAsync(serviceId);
        }

        [HttpPost]
        public async Task<ActionResult<ServiceDto>> AddServiceAsync(ServiceDto service)
        {
            try
            {
                return CreatedAtAction(nameof(GetServicesAsync), await _serviceService.AddServiceAsync(service));
            }
            catch (NotFoundExeption ex)
            {
                return NotFound(ex);
            }
        }

        [HttpPatch("{serviceId}/Description")]
        public async Task<ActionResult> UpdateServiceDescription(int serviceId, string description)
        {
            try
            {
                await _serviceService.UpdateServiceDescriptionAsync(serviceId, description);
                return NoContent();
            }
            catch (NotFoundExeption ex)
            {
                return NotFound(ex);
            }
        }

        [HttpPatch("{serviceId}/ServiceType")]
        public async Task<ActionResult> UpdateServiceServiceType(int serviceId, int serviceTypeId)
        {
            try
            {
                await _serviceService.UpdateServiceServiceTypeAsync(serviceId, serviceTypeId);
                return NoContent();
            }
            catch (NotFoundExeption ex)
            {
                return NotFound(ex);
            }
        }

        [HttpDelete("{serviceId}")]
        public async Task<ActionResult> DeleteService(int serviceId)
        {
            try
            {
                await _serviceService.DeleteServiceAsync(serviceId);
                return NoContent();
            }
            catch (NotFoundExeption ex)
            {
                return NotFound(ex);
            }
        }
    }
}
