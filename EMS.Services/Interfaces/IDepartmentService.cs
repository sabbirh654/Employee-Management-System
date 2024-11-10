using EMS.Repository.Models;

namespace EMS.Services.Interfaces;

public interface IDepartmentService
{
    Task<IEnumerable<Department>> GetAllDepartments();
    Task<Department> GetDepartmentById(int id);
    Task AddDepartment(Department department);
    Task UpdateDepartment(Department department);
    Task DeleteDepartment(int id);
}
