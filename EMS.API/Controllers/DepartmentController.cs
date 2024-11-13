using EMS.API.Helpers;
using EMS.Repository.Models;
using EMS.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EMS.API.Controllers;

[Route("api/[Controller]")]
[ApiController]
public class DepartmentController : ControllerBase
{
    private readonly IDepartmentService _departmentService;
    private readonly IOperationLogService _operationLogService;

    public DepartmentController(IDepartmentService departmentService, IOperationLogService operationLogService)
    {
        _departmentService = departmentService;
        _operationLogService = operationLogService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllDepartments()
    {
        var departments = await _departmentService.GetAllDepartments();
        return Ok(departments);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetDepartmentById(int id)
    {
        var department = await _departmentService.GetDepartmentById(id);
        if (department == null) return NotFound();
        return Ok(department);
    }

    [HttpPost]
    public async Task<IActionResult> CreateDepartment(Department department)
    {
        await _departmentService.AddDepartment(department);

        var log = Utility.CreateLogData(
            "Add",
            "Department",
            string.Empty,
            DateTime.UtcNow
            );

        await _operationLogService.LogOperationAsync(log);
        return CreatedAtAction(nameof(GetDepartmentById), new { id = department.Id }, department);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateDepartment(int id, Department department)
    {
        if (id != department.Id) return BadRequest();
        await _departmentService.UpdateDepartment(department);

        var log = Utility.CreateLogData(
            "Update",
            "Department",
            department.Id.ToString(),
            DateTime.UtcNow
            );

        await _operationLogService.LogOperationAsync(log);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteDepartment(int id)
    {
        await _departmentService.DeleteDepartment(id);

        var log = Utility.CreateLogData(
            "Delete",
            "Department",
            id.ToString(),
            DateTime.UtcNow
            );

        await _operationLogService.LogOperationAsync(log);
        return NoContent();
    }
}
