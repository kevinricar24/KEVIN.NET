namespace KEVIN.Domain.Dtos
{
    public class EmployeeDto
    {
        public int EmployeeId { get; set; }
        public string? FirstName { get; set; }
        public string LastName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string? PhoneNumber { get; set; }
        public DateTime HireDate { get; set; }
        public int JobId { get; set; }
        public decimal Salary { get; set; }
        public int? ManagerId { get; set; }
        public int? DepartmentId { get; set; }
    }
}
