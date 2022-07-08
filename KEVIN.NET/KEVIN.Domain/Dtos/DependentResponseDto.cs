namespace KEVIN.Domain.Dtos
{
    public class DependentResponseDto
    {
        public int DependentId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Relationship { get; set; }
        public EmployeeResponseDto Employee { get; set; }
    }
}
