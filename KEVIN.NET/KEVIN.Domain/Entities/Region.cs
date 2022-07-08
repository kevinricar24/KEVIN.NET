using System;
using System.Collections.Generic;

namespace KEVIN.Domain.Entities
{
    public partial class Region
    {
        public Region()
        {
            Countries = new HashSet<Country>();
        }

        public int RegionId { get; set; }
        public string? RegionName { get; set; }

        public virtual ICollection<Country> Countries { get; set; }
    }
}
