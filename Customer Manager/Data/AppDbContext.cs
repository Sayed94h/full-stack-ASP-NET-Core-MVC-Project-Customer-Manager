
using Customer_Manager.Data.DataModels;
using Microsoft.EntityFrameworkCore;

namespace Customer_Manager.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options) { }

        public DbSet<CustomerModel> Customers { get; set; }
    }
}
