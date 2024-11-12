using Dapper;
using EMS.Repository.Factory;
using EMS.Repository.Helpers;
using EMS.Repository.Interfaces;
using EMS.Repository.Models;
using System.Data;

namespace EMS.Repository.Implementations;

public class DesignationRepository : IDesignationRepository
{
    private readonly IDatabaseFactory _databaseFactory;

    public DesignationRepository(IDatabaseFactory databaseFactory)
    {
        _databaseFactory = databaseFactory;
    }

    public async Task AddAsync(Designation designation)
    {
        using (var db = _databaseFactory.CreateSqlServerConnection())
        {
            var parameters = new DynamicParameters();
            parameters.Add("@Name", designation.Name);

            await db.ExecuteAsync(
                StoredProcName.AddNewDesignation,
                parameters,
                commandType: CommandType.StoredProcedure);
        }
    }

    public async Task DeleteAsync(int id)
    {
        using (var db = _databaseFactory.CreateSqlServerConnection())
        {
            var parameters = new DynamicParameters();
            parameters.Add("@Id", id);

            await db.ExecuteAsync(
                    StoredProcName.DeleteDesignation,
                    parameters,
                    commandType: CommandType.StoredProcedure);
        }
    }

    public async Task<IEnumerable<Designation>> GetAllAsync()
    {
        using (var db = _databaseFactory.CreateSqlServerConnection())
        {
            var designations = await db.QueryAsync<Designation>(
                StoredProcName.GetAllDesignations,
                commandType: CommandType.StoredProcedure);

            return designations;
        }
    }

    public async Task<Designation> GetByIdAsync(int id)
    {
        using (var db = _databaseFactory.CreateSqlServerConnection())
        {
            var parameters = new DynamicParameters();
            parameters.Add("@Id", id);

            var designation = await db.QueryFirstOrDefaultAsync<Designation>(
                StoredProcName.GetDesignationById,
                parameters,
                commandType: CommandType.StoredProcedure);

            return designation;
        }
    }

    public async Task UpdateAsync(Designation designation)
    {
        using (var db = _databaseFactory.CreateSqlServerConnection())
        {
            var parameters = new DynamicParameters();
            parameters.Add("@Id", designation.Id);
            parameters.Add("@Name", designation.Name);

            await db.ExecuteAsync(
                StoredProcName.UpdateDepartment,
                parameters,
                commandType: CommandType.StoredProcedure);
        }
    }
}
