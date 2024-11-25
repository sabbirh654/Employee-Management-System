using Dapper;
using EMS.Repository.Factory;
using EMS.Repository.Interfaces;
using EMS.Repository.Models;
using System.Data;

namespace EMS.Repository.Implementations;

public class AttendanceRepository : IAttendanceRepository
{
    private readonly IDatabaseFactory _databaseFactory;

    public AttendanceRepository(IDatabaseFactory databaseFactory)
    {
        _databaseFactory = databaseFactory;
    }

    public async Task AddAsync(Attendance attendance)
    {
        using (var db = _databaseFactory.CreatePostgresSqlConnection())
        {
            var parameters = new DynamicParameters();
            parameters.Add("employee_id", attendance.EmployeeId, DbType.Int32);
            parameters.Add("date", DateTime.Parse(attendance.Date), DbType.Date);                 // Pass date as string
            parameters.Add("check_in_time", TimeSpan.Parse(attendance.CheckInTime), DbType.Time); // Pass directly as string
            parameters.Add("check_out_time", TimeSpan.Parse(attendance.CheckOutTime), DbType.Time); // Pass directly as string

            await db.ExecuteAsync(
                "insert_attendance",
                parameters,
                commandType: CommandType.StoredProcedure
            );
        }
    }
}
