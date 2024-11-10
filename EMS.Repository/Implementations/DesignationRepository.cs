using EMS.Repository.Interfaces;
using EMS.Repository.Models;

namespace EMS.Repository.Implementations;

public class DesignationRepository : IRepository<Designation>
{
    public Task AddAsync(Designation entity)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Designation>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<Designation> GetByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task UpdateAsync(Designation entity)
    {
        throw new NotImplementedException();
    }
}
