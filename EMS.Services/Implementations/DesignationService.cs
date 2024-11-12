using EMS.Repository.Interfaces;
using EMS.Repository.Models;
using EMS.Services.Interfaces;

namespace EMS.Services.Implementations;

public class DesignationService : IDesignationService
{
    private readonly IDesignationRepository _repository;

    public DesignationService(IDesignationRepository repository)
    {
        _repository = repository;
    }

    public async Task AddDesignation(Designation designation)
    {
        await _repository.AddAsync(designation);
    }

    public async Task DeleteDesignation(int id)
    {
        await _repository.DeleteAsync(id);
    }

    public async Task<IEnumerable<Designation>> GetAllDesignations()
    {
        return await _repository.GetAllAsync();
    }

    public async Task<Designation> GetDesignationById(int id)
    {
        return await _repository.GetByIdAsync(id);
    }

    public async Task UpdateDesignation(Designation designation)
    {
        await _repository.UpdateAsync(designation);
    }
}
