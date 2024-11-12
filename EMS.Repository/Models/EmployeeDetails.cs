namespace EMS.Repository.Models;

public class EmployeeDetails : Employee
{
    public string Designation { get; set; } = null!;
    public string Department { get; set; } = null!;
}
