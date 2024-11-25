using EMS.Repository.Models;

namespace EMS.Services.Interfaces;

public interface IAttendanceService
{
    public Task AddEmployeeAttendance(Attendance attendance);
}
