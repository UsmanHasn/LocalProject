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
            modelBuilder.Entity<UserActivityInfoLog>().Property(p => p.Id).HasColumnName("ActivityId");
            modelBuilder.Entity<Services>().Property(p => p.Id).HasColumnName("ServiceId");
            modelBuilder.Entity<Pages>().Property(p => p.Id).HasColumnName("PageId");
            modelBuilder.Entity<RolePermissions>().Property(p => p.Id).HasColumnName("RolePermissionId");
            modelBuilder.Entity<UserDelegatedPermissions>().Property(p => p.Id).HasColumnName("UserPermissionId");
            modelBuilder.Entity<SystemSettings>().Property(p => p.Id).HasColumnName("SystemSettingId");

            //Lookup
            modelBuilder.Entity<UserStatusLookup>().Property(p => p.Id).HasColumnName("UserStatusId");
            modelBuilder.Entity<NationalityLookup>().Property(p => p.Id).HasColumnName("NationalityId");
            modelBuilder.Entity<CountryLookup>().Property(p => p.Id).HasColumnName("CountryId");
            modelBuilder.Entity<LanguageLookup>().Property(p => p.Id).HasColumnName("LanguageId");
            modelBuilder.Entity<ServiceCategoryLookup>().Property(p => p.Id).HasColumnName("ServiceCategoryId");
            modelBuilder.Entity<ServiceSubCategoryLookup>().Property(p => p.Id).HasColumnName("ServiceSubCategoryId");

        }

        // DbSet properties for your entities
        public DbSet<Roles> Roles { get; set; }
        public DbSet<Users> Users { get; set; }
        public DbSet<UserStatusLookup> UserStatusLookup { get; set; }
        public DbSet<UserInRole> UserInRole { get; set; }
        public DbSet<UserActivityInfoLog> UserActivityInfoLog { get; set; }
        public DbSet<Menu> Menu { get; set; }
        public DbSet<Services> Services { get; set; }
        public DbSet<Pages> Pages { get; set; }
        public DbSet<RolePermissions> RolePermissions { get; set; }
        public DbSet<UserDelegatedPermissions> UserDelegatedPermissions { get; set; }
        public DbSet<SystemSettings> SystemSettings { get; set; }
        //Lookup
        public DbSet<NationalityLookup> NationalityLookup { get; set; }
        public DbSet<CountryLookup> CountryLookup { get; set; }
        public DbSet<LanguageLookup> LanguageLookup { get; set; }
        public DbSet<ServiceCategoryLookup> ServiceCategoryLookup { get; set; }
        public DbSet<ServiceSubCategoryLookup> ServiceSubCategoryLookup { get; set; }
    }
}

