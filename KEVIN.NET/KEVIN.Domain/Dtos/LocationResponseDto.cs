namespace KEVIN.Domain.Dtos
{
    public class LocationResponseDto
    {
        public int LocationId { get; set; }
        public string? StreetAddress { get; set; }
        public string? PostalCode { get; set; }
        public string City { get; set; }
        public string? StateProvince { get; set; }

        public virtual CountryResponseDto Country { get; set; }
        public virtual List<DepartmentResponseDto> Departments { get; set; }
    }
}
