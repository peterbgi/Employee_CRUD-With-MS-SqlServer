using EmployeeCRUDPortal.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace EmployeeCRUDPortal.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
            
        }

        public DbSet<Employee> Empolyess { get; set; }


    }
}
