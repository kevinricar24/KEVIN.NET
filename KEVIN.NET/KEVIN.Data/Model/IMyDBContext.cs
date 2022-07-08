using KEVIN.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace KEVIN.Data.Model
{
    public interface IMyDBContext
    {
       DbSet<Country> Countries { get; set; }
       DbSet<Department> Departments { get; set; }
       DbSet<Dependent> Dependents { get; set; }
       DbSet<Employee> Employees { get; set; }
       DbSet<Job> Jobs { get; set; }
       DbSet<Location> Locations { get; set; }
       DbSet<Region> Regions { get; set; }
        int SaveChanges();
    }
}
