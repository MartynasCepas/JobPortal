using JobPortal.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace JobPortal.Data
{
    public class RestContext : DbContext
    {
        public DbSet<Offer> topics {get;set;}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB; Initial Catalog=RestDemo");
        }
    }
}
