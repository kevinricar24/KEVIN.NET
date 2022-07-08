namespace KEVIN.Domain.Dtos
{
    public class JobResponseDto
    {
        public int JobId { get; set; }
        public string JobTitle { get; set; } = null!;
        public decimal? MinSalary { get; set; }
        public decimal? MaxSalary { get; set; }
    }
}
