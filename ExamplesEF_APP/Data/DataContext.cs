using ExamplesEF.Model;
using Microsoft.EntityFrameworkCore;

namespace ExamplesEF.Data
   {
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            
        }
        public DbSet<Region> Region { get; set; }
        public DbSet<Employee> Employees { get; set; }
        
    }
}
