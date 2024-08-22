using ITeam.Application.DTOs;
using ITeam.Application.Services;
using ITeam.Application.Services.Exaptions;
using Microsoft.AspNetCore.Http;
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

        [HttpPost]
        public async Task<ActionResult> AddServiceAsync(ServiceDto service)
        {
            try
            {
                await _serviceService.AddServiceAsync(service);
                return Ok();
            }
            catch (NotFoundExeption ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPatch("{serviceId}")]
        public async Task<ActionResult> UpdateServiceDescription(int serviceId, string description)
        {
            try
            {
                await _serviceService.UpdateServiceDescriptionAsync(serviceId, description);
                return Ok();
            }
            catch (NotFoundExeption ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPatch("{serviceId}")]
        public async Task<ActionResult> UpdateServiceServiceType(int serviceId, int serviceTypeId)
        {
            try
            {
                await _serviceService.UpdateServiceServiceTypeAsync(serviceId, serviceTypeId);
                return Ok();
            }
            catch (NotFoundExeption ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpDelete("{serviceId}")]
        public async Task<ActionResult> DeleteService(int serviceId)
        {
            try
            {
                await _serviceService.DeleteServiceAsync(serviceId);
                return Ok();
            }
            catch (NotFoundExeption ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
