using EMS.Repository.Models;

namespace EMS.Services.Interfaces;

public interface IEmployeeService
{
    Task<IEnumerable<EmployeeDetails>> GetAllEmployees();
    Task<EmployeeDetails> GetEmployeeById(int id);
    Task AddEmployee(Employee employee);
    Task UpdateEmployee(Employee employee);
    Task DeleteEmployee(int id);
}
