using EMS.Repository.Models;

namespace EMS.Repository.Interfaces;

public interface IEmployeeRepository
{
    Task<IEnumerable<EmployeeDetails>> GetAllAsync();
    Task<EmployeeDetails> GetByIdAsync(int id);
    Task AddAsync(Employee employee);
    Task UpdateAsync(Employee employee);
    Task DeleteAsync(int id);
}
