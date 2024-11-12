using EMS.Repository.Models;

namespace EMS.Repository.Interfaces;

public interface IDesignationRepository
{
    Task<IEnumerable<Designation>> GetAllAsync();
    Task<Designation> GetByIdAsync(int id);
    Task AddAsync(Designation designation);
    Task UpdateAsync(Designation designation);
    Task DeleteAsync(int id);
}
