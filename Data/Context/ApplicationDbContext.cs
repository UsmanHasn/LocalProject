using Domain.Entities;
using Domain.Entities.Lookups;
using Microsoft.EntityFrameworkCore;

namespace Data.Context
{
    public class ApplicationDbContext : DbContext
       {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            //Tables
            modelBuilder.Entity<Roles>().Property(p => p.Id).HasColumnName("RoleId");
            modelBuilder.Entity<Users>().Property(p => p.Id).HasColumnName("UserId");
            modelBuilder.Entity<Menu>().Property(p => p.Id).HasColumnName("MenuId");
            modelBuilder.Entity<UserInRole>().Property(p => p.Id).HasColumnName("UserRoleId");


            //Lookup
            modelBuilder.Entity<NationalityLookup>().Property(p => p.Id).HasColumnName("NationalityId");
            modelBuilder.Entity<CountryLookup>().Property(p => p.Id).HasColumnName("CountryId");
            modelBuilder.Entity<LanguageLookup>().Property(p => p.Id).HasColumnName("LanguageId");

        }

        // DbSet properties for your entities
        public DbSet<Roles> Roles { get; set; }
        public DbSet<Users> Users { get; set; }
        public DbSet<UserInRole> UserInRole { get; set; }
        public DbSet<UserActivityInfoLog> UserActivityInfoLog { get; set; }
        public DbSet<Menu> Menu { get; set; }
        public DbSet<NationalityLookup> NationalityLookup { get; set; }
        public DbSet<CountryLookup> CountryLookup { get; set; }
        public DbSet<LanguageLookup> LanguageLookup { get; set; }
    }
}

