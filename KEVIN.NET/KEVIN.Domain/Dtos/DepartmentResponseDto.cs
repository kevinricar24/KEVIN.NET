namespace KEVIN.Domain.Dtos
{
    public class DepartmentResponseDto
    {
        public int DepartmentId { get; set; }
        public string DepartmentName { get; set; }
        public int? LocationId { get; set; }

        public LocationResponseDto? Location { get; set; }
        public List<EmployeeResponseDto> Employees { get; set; }
    }
}
