using EMS.Repository.Models;

namespace EMS.Services.Interfaces;

public interface IDesignationService
{
    Task<IEnumerable<Designation>> GetAllDesignations();
    Task<Designation> GetDesignationById(int id);
    Task AddDesignation(Designation designation);
    Task UpdateDesignation(Designation designation);
    Task DeleteDesignation(int id);
}
