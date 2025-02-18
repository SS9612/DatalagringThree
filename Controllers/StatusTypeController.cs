using Buisness.Services;
using Buisness.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Presentation.ConsoleApp.Controllers
{
    [ApiController]
    [Route("api/statustypes")]
    public class StatusTypeController : ControllerBase
    {
        private readonly IStatusTypeService _statusTypeService;

        public StatusTypeController(IStatusTypeService statusTypeService)
        {
            _statusTypeService = statusTypeService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateStatusType([FromBody] StatusTypeRegistrationForm form)
        {
            if (form == null || string.IsNullOrWhiteSpace(form.Statusname))
            {
                return BadRequest("Invalid status type data.");
            }

            await _statusTypeService.CreateStatusTypeAsync(form);
            return CreatedAtAction(nameof(GetStatusTypeById), new { id = form.Statusname }, form);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllStatusTypes()
        {
            var statusTypes = await _statusTypeService.GetAllStatusTypesAsync();
            if (statusTypes == null || !statusTypes.Any())
            {
                return NotFound("No status types found.");
            }

            return Ok(statusTypes);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetStatusTypeById(int id)
        {
            var statusType = await _statusTypeService.GetStatusTypeByIdAsync(id);
            if (statusType == null)
            {
                return NotFound("StatusType not found.");
            }

            return Ok(statusType);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateStatusType(int id, [FromBody] StatusType updatedStatusType)
        {
            if (updatedStatusType == null || string.IsNullOrWhiteSpace(updatedStatusType.Statusname))
            {
                return BadRequest("Invalid status type data.");
            }

            updatedStatusType.Id = id;
            var success = await _statusTypeService.UpdateStatusTypeAsync(updatedStatusType);
            if (!success)
            {
                return NotFound("StatusType not found.");
            }

            return Ok("StatusType updated successfully!");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStatusType(int id)
        {
            var success = await _statusTypeService.DeleteStatusTypeAsync(id);
            if (!success)
            {
                return NotFound("StatusType not found.");
            }

            return Ok("StatusType deleted successfully!");
        }
    }
}
