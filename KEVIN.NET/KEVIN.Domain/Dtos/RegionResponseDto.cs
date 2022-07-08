using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KEVIN.Domain.Dtos
{
    public class RegionResponseDto
    {
        public int RegionId { get; set; }
        public string? RegionName { get; set; }

        public List<CountryResponseDto> Countries { get; set; }
    }
}
