using EMS.API.Helpers;
using EMS.Repository.Models;
using EMS.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EMS.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class EmployeeController : ControllerBase
{
    private readonly IEmployeeService _employeeService;
    private readonly IOperationLogService _operationLogService;

    public EmployeeController(IEmployeeService employeeService, IOperationLogService operationLogService)
    {
        _employeeService = employeeService;
        _operationLogService = operationLogService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllEmployees()
    {
        var employees = await _employeeService.GetAllEmployees();
        return Ok(employees);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetEmployeeById(int id)
    {
        var employee = await _employeeService.GetEmployeeById(id);
        if (employee == null) return NotFound();
        return Ok(employee);
    }

    [HttpPost]
    public async Task<IActionResult> CreateEmployee(Employee employee)
    {
        await _employeeService.AddEmployee(employee);

        var log = Utility.CreateLogData(
            "Add",
            "Employee",
            string.Empty,
            DateTime.UtcNow
        );

        await _operationLogService.LogOperationAsync(log);
        return CreatedAtAction(nameof(GetEmployeeById), new { id = employee.Id }, employee);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateEmployee(int id, Employee employee)
    {
        if (id != employee.Id) return BadRequest();
        await _employeeService.UpdateEmployee(employee);
        var log = Utility.CreateLogData(
            "Update",
            "Employee",
            employee.Id.ToString(),
            DateTime.UtcNow
        );

        await _operationLogService.LogOperationAsync(log);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteEmployee(int id)
    {
        await _employeeService.DeleteEmployee(id);
        var log = Utility.CreateLogData(
            "Delete",
            "Employee",
            id.ToString(),
            DateTime.UtcNow
        );

        await _operationLogService.LogOperationAsync(log);
        return NoContent();
    }
}
