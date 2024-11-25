using EMS.Repository.Interfaces;
using EMS.Repository.Models;
using EMS.Services.Interfaces;

namespace EMS.Services.Implementations;

public class AttendanceService : IAttendanceService
{
    private readonly IAttendanceRepository _attendanceRepository;

    public AttendanceService(IAttendanceRepository attendanceRepository)
    {
        _attendanceRepository = attendanceRepository;
    }

    public async Task AddEmployeeAttendance(Attendance attendance)
    {
        await _attendanceRepository.AddAsync(attendance);
    }
}
