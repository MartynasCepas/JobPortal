using System;
using JobPortal.Data.Dtos.Auth;
using JobPortal.Data.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace JobPortal.Data
{
    public class RestContext : IdentityDbContext<User>
    {
        public DbSet<Offer> Offers {get;set;}
        public DbSet<Application> Applications { get; set; }
        public DbSet<Response> Responses { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("User ID=pvnbmlconmjuoc;Password=pvnbmlconmjuoc;Password=396aab8730ebbafca921e9dd61c3a7336b31ea6e5f33609931aca63b03514639;Host=ec2-54-72-155-238.eu-west-1.compute.amazonaws.com;Port=5432;Database=d5tsgmr2bfip5j;Pooling=true;SSL Mode=Require;TrustServerCertificate=True;");
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
          //  builder.Entity<Offer>().HasOne(b => b.User).WithMany(e => e.Offers).HasForeignKey(e => e.UserId)
          //      .OnDelete(DeleteBehavior.Cascade);
            builder.Entity<User>().HasMany(e => e.Offers).WithOne(b => b.User).HasForeignKey(e => e.UserId);
        }
    }
}
