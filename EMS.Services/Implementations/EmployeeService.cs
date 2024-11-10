using EMS.Repository.Models;
using EMS.Services.Interfaces;

namespace EMS.Services.Implementations;

public class EmployeeService : IEmployeeService
{
    public Task AddEmployee(Employee employee)
    {
        throw new NotImplementedException();
    }

    public Task DeleteEmployee(int id)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Employee>> GetAllEmployees()
    {
        throw new NotImplementedException();
    }

    public Task<Employee> GetEmployeeById(int id)
    {
        throw new NotImplementedException();
    }

    public Task UpdateEmployee(Employee employee)
    {
        throw new NotImplementedException();
    }
}
