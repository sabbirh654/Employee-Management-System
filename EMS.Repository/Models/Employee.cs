namespace EMS.Repository.Models;

public class Employee
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string? Phone { get; set; }
    public string? Address { get; set; }
    public DateTime DOB { get; set; }
    public int DepartmentId { get; set; }
    public int DesignationId { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
}
