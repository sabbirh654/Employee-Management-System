using EMS.Repository.Models;

namespace EMS.Repository.Interfaces;

public interface IAttendanceRepository
{
    Task AddAsync(Attendance attendance);
}
