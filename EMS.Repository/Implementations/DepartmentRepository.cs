using EMS.Repository.Interfaces;
using EMS.Repository.Models;

namespace EMS.Repository.Implementations;

public class DepartmentRepository : IRepository<Department>
{
    public Task AddAsync(Department entity)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Department>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<Department> GetByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task UpdateAsync(Department entity)
    {
        throw new NotImplementedException();
    }
}
