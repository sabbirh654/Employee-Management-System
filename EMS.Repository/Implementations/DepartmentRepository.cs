using Dapper;
using EMS.Repository.Factory;
using EMS.Repository.Helpers;
using EMS.Repository.Interfaces;
using EMS.Repository.Models;
using System.Data;

namespace EMS.Repository.Implementations;

public class DepartmentRepository : IRepository<Department>
{
    private readonly IDatabaseFactory _databaseFactory;

    public DepartmentRepository(IDatabaseFactory databaseFactory)
    {
        _databaseFactory = databaseFactory;
    }
    public async Task AddAsync(Department department)
    {
        using (var db = _databaseFactory.CreateSqlServerConnection())
        {
            var parameters = new DynamicParameters();
            parameters.Add("@Name", department.Name);

            await db.ExecuteAsync(
                StoredProcName.AddNewDepartment, 
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
                    StoredProcName.DeleteDepartment,
                    parameters,
                    commandType: CommandType.StoredProcedure);
        }
    }

    public async Task<IEnumerable<Department>> GetAllAsync()
    {
        using (var db = _databaseFactory.CreateSqlServerConnection())
        {
            var departments =  await db.QueryAsync<Department>(
                StoredProcName.GetAllDepartments, 
                commandType: CommandType.StoredProcedure);

            return departments;
        }
    }

    public async Task<Department> GetByIdAsync(int id)
    {
        using (var db = _databaseFactory.CreateSqlServerConnection())
        {
            var parameters = new DynamicParameters();
            parameters.Add("@Id", id);

            var department = await db.QueryFirstOrDefaultAsync<Department>(
                StoredProcName.GetDepartmentById, 
                parameters, 
                commandType: CommandType.StoredProcedure);

            return department;
        }
    }

    public async Task UpdateAsync(Department department)
    {
        using (var db = _databaseFactory.CreateSqlServerConnection())
        {
            var parameters = new DynamicParameters();
            parameters.Add("@Id", department.Id);
            parameters.Add("@Name", department.Name);

            await db.ExecuteAsync(
                StoredProcName.UpdateDepartment, 
                parameters, 
                commandType: CommandType.StoredProcedure);
        }
    }
}
