namespace KEVIN.Domain.Dtos
{
    public class EmployeeResponseDto
    {
        public int EmployeeId { get; set; }
        public string? FirstName { get; set; }
        public string LastName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string? PhoneNumber { get; set; }
        public DateTime HireDate { get; set; }
        public decimal Salary { get; set; }

        public DepartmentResponseDto? Department { get; set; }
        public JobResponseDto Job { get; set; } = null!;
        public EmployeeResponseDto? Manager { get; set; }
        public List<DependentResponseDto> Dependents { get; set; }
        public List<EmployeeResponseDto> InverseManager { get; set; }
    }
}
