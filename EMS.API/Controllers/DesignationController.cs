using EMS.API.Helpers;
using EMS.Repository.Models;
using EMS.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EMS.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class DesignationController : ControllerBase
{
    private readonly IDesignationService _designationService;
    private readonly IOperationLogService _operationLogService;

    public DesignationController(IDesignationService designationService, IOperationLogService operationLogService)
    {
        _designationService = designationService;
        _operationLogService = operationLogService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllDesignations()
    {
        var designations = await _designationService.GetAllDesignations();
        return Ok(designations);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetDesignationById(int id)
    {
        var designation = await _designationService.GetDesignationById(id);
        if (designation == null) return NotFound();
        return Ok(designation);
    }

    [HttpPost]
    public async Task<IActionResult> CreateDesignation(Designation designation)
    {
        await _designationService.AddDesignation(designation);
        var log = Utility.CreateLogData(
            "Add",
            "Designation",
            string.Empty,
            DateTime.UtcNow
        );

        await _operationLogService.LogOperationAsync(log);
        return CreatedAtAction(nameof(GetDesignationById), new { id = designation.Id }, designation);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateDesignation(int id, Designation designation)
    {
        if (id != designation.Id) return BadRequest();
        await _designationService.UpdateDesignation(designation);

        var log = Utility.CreateLogData(
            "Update",
            "Designation",
            designation.Id.ToString(),
            DateTime.UtcNow
        );

        await _operationLogService.LogOperationAsync(log);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteDesignation(int id)
    {
        await _designationService.DeleteDesignation(id);

        var log = Utility.CreateLogData(
            "Delete",
            "Designation",
            id.ToString(),
            DateTime.UtcNow
        );

        await _operationLogService.LogOperationAsync(log);
        return NoContent();
    }
}
