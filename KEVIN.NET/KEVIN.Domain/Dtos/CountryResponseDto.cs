namespace KEVIN.Domain.Dtos
{
    public class CountryResponseDto
    {
        public string CountryId { get; set; }
        public string? CountryName { get; set; }
        public RegionResponseDto Region { get; set; } 
        public List<LocationResponseDto> Locations { get; set; }
    }
}
