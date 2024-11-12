using Dapper;
using EMS.Repository.Factory;
using EMS.Repository.Helpers;
using EMS.Repository.Interfaces;
using EMS.Repository.Models;
using System.Data;

namespace EMS.Repository.Implementations;

public class EmployeeRepository : IEmployeeRepository
{
    private readonly IDatabaseFactory _databaseFactory;

    public EmployeeRepository(IDatabaseFactory databaseFactory)
    {
        _databaseFactory = databaseFactory;
    }
    public async Task AddAsync(Employee employee)
    {
        using (var db = _databaseFactory.CreateSqlServerConnection())
        {
            var parameters = new DynamicParameters();
            parameters.Add("@Name", employee.Name);
            parameters.Add("@Email", employee.Email);
            parameters.Add("@Phone", employee.Phone);
            parameters.Add("@Address", employee.Address);
            parameters.Add("@DOB", employee.DOB);
            parameters.Add("@DepartmentId", employee.DepartmentId);
            parameters.Add("@DesignationId", employee.DesignationId);

            await db.ExecuteAsync(
                StoredProcName.AddNewEmployee,
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
                    StoredProcName.DeleteEmployee,
                    parameters,
                    commandType: CommandType.StoredProcedure);
        }
    }

    public async Task<IEnumerable<EmployeeDetails>> GetAllAsync()
    {
        using (var db = _databaseFactory.CreateSqlServerConnection())
        {
            return await db.QueryAsync<EmployeeDetails>(
                    StoredProcName.GetAllEmployees,
                    commandType: CommandType.StoredProcedure
                );
        }
    }

    public async Task<EmployeeDetails> GetByIdAsync(int id)
    {
        using (var db = _databaseFactory.CreateSqlServerConnection())
        {
            var parameters = new DynamicParameters();
            parameters.Add("@Id", id);

            var employee = await db.QueryFirstOrDefaultAsync<EmployeeDetails>(
                    StoredProcName.GetAllEmployees,
                    commandType: CommandType.StoredProcedure
                );

            return employee;
        }
    }

    public async Task UpdateAsync(Employee employee)
    {
        using (var db = _databaseFactory.CreateSqlServerConnection())
        {
            var parameters = new DynamicParameters();
            parameters.Add("@Id", employee.Id);
            parameters.Add("@Name", employee.Name);
            parameters.Add("@Email", employee.Email);
            parameters.Add("@Phone", employee.Phone);
            parameters.Add("@DOB", employee.DOB);

            await db.ExecuteAsync(
                StoredProcName.UpdateEmployee,
                parameters,
                commandType: CommandType.StoredProcedure);
        }
    }
}
