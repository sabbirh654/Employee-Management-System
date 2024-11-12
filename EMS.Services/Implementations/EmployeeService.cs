using EMS.Repository.Interfaces;
using EMS.Repository.Models;
using EMS.Services.Interfaces;

namespace EMS.Services.Implementations;

public class EmployeeService : IEmployeeService
{
    private readonly IEmployeeRepository _repository;

    public EmployeeService(IEmployeeRepository repository)
    {
        _repository = repository;
    }

    public async Task AddEmployee(Employee employee)
    {
        await _repository.AddAsync(employee);
    }

    public async Task DeleteEmployee(int id)
    {
        await _repository.DeleteAsync(id);
    }

    public async Task<IEnumerable<EmployeeDetails>> GetAllEmployees()
    {
        return await _repository.GetAllAsync();
    }

    public async Task<EmployeeDetails> GetEmployeeById(int id)
    {
        return await _repository.GetByIdAsync(id);
    }

    public async Task UpdateEmployee(Employee employee)
    {
        await _repository.UpdateAsync(employee);
    }
}
