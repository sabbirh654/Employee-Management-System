using EMS.Repository.Interfaces;
using EMS.Repository.Models;
using EMS.Services.Interfaces;

namespace EMS.Services.Implementations;

public class DepartmentService : IDepartmentService
{
    private readonly IDepartmentRepository _repository;

    public DepartmentService(IDepartmentRepository repository)
    {
        _repository = repository;
    }
    public async Task AddDepartment(Department department)
    {
        await _repository.AddAsync(department);
    }

    public async Task DeleteDepartment(int id)
    {
        await _repository.DeleteAsync(id);
    }

    public async Task<IEnumerable<Department>> GetAllDepartments()
    {
        return await _repository.GetAllAsync();
    }

    public async Task<Department> GetDepartmentById(int id)
    {
        return await _repository.GetByIdAsync(id);
    }

    public async Task UpdateDepartment(Department department)
    {
        await _repository.UpdateAsync(department);
    }
}
