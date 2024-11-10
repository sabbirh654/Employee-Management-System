using EMS.Repository.Interfaces;
using EMS.Repository.Models;

namespace EMS.Repository.Implementations;

public class EmployeeRepository : IRepository<Employee>
{
    public Task AddAsync(Employee entity)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Employee>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<Employee> GetByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task UpdateAsync(Employee entity)
    {
        throw new NotImplementedException();
    }
}
