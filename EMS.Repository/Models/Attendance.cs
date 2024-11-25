namespace EMS.Repository.Models;

public class Attendance
{
    public int Id { get; set; }
    public int EmployeeId { get; set; }
    public string Date { get; set; } = null!;
    public string CheckInTime { get; set; } = null!;
    public string CheckOutTime { get; set; } = null!;
}
