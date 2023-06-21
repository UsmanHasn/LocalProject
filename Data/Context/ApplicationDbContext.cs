using System;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using Domain.Entities;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Threading.Tasks;
using System.Data.Common;

namespace Data.Context
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, IdentityModel.CustomRole, int,
            IdentityModel.CustomUserLogin, IdentityModel.CustomUserRole, IdentityModel.CustomUserClaim>
    {
        public ApplicationDbContext()
            : base("SJCContext")
        {
            //Check if these values need to be true or false. I would think true as false means eager loading
            Configuration.LazyLoadingEnabled = false;
            Configuration.ProxyCreationEnabled = false;
            //Configuration.AutoDetectChangesEnabled = false;
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            //Configuring ASP NEt Identity Tables

            //User and User Profile
            modelBuilder.Entity<ApplicationUser>().ToTable("AspNetUsers");
            modelBuilder.Entity<IdentityModel.CustomRole>().ToTable("AspNetRoles");

            modelBuilder.Entity<ApplicationUser>().Property(p => p.Id).HasColumnName("UserId");
            modelBuilder.Entity<IdentityModel.CustomRole>().Property(p => p.Id).HasColumnName("RoleId");
            modelBuilder.Entity<UserProfile>().Property(p => p.Id).HasColumnName("UserId");
            modelBuilder.Entity<UserProfile>().HasRequired(e => e.User).WithRequiredDependent(r => r.User);

        }
        //Define all entitys as DBSet
        //User and UserProfile
        public DbSet<PasswordHistory> PasswordHistory { get; set; }
        public DbSet<UserProfile> UserProfile { get; set; }
        public DbSet<UserTimeInInfoLog> UserTimeInInfoLog { get; set; }
        //Creates a ApplicationDBContext
        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

    }
}
