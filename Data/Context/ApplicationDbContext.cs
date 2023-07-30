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
            modelBuilder.Entity<UserActivityInfoLog>().Property(p => p.UserId).HasColumnName("UserId");
            modelBuilder.Entity<Services>().Property(p => p.ServiceSubCategoryId).HasColumnName("ServiceId");
            modelBuilder.Entity<Pages>().Property(p => p.Id).HasColumnName("PageId");
            modelBuilder.Entity<RolePermissions>().Property(p => p.Id).HasColumnName("RolePermissionId");
            modelBuilder.Entity<UserDelegatedPermissions>().Property(p => p.Id).HasColumnName("UserPermissionId");
            modelBuilder.Entity<SystemSettings>().Property(p => p.Id).HasColumnName("SystemSettingId");
            modelBuilder.Entity<SJCESP_AlertandNotification>().HasKey(m => new { m.CaseID, m.Affichable });
            modelBuilder.Entity<SJCESP_CaseInformation>().HasKey(m => new { m.Identifiant, m.Affichable });
            modelBuilder.Entity<SJCESP_Cases>().HasKey(m => new { m.CRNO ,m.IdDossierCivil });
            modelBuilder.Entity<SJCESP_civilno>().HasKey(m => new { m.IdDossierCivil, m.NumeroPieceIdentite });
            modelBuilder.Entity<SJCESP_Denominations>().HasKey(m => new { m.IdDossierCivil, m.NumRegistreCommerce});
            modelBuilder.Entity<SJCESP_Decision>().HasKey(m => new { m.IdDossierCivil});
            modelBuilder.Entity<SJCESP_Judge_Information>().HasKey(m => new { m.IdDossierCivil });
            modelBuilder.Entity<SJCESP_LawyerAddress>().HasKey(m => new { m.LicenseNo });
            modelBuilder.Entity<SJCESP_LawyerCaces>().HasKey(m => new { m.CaseID ,m.NumeroPieceIdentite });
            modelBuilder.Entity<SJCESP_LawyerInformation>().HasKey(m => new { m.lawyerid, m.CivilNo });
            modelBuilder.Entity<SJCESP_RoleParties>().HasKey(m => new { m.CaseID, m.CivilNumberParties });
            modelBuilder.Entity<SJCESP_Session_Information>().HasKey(m => new { m.CaseID });
            //Lookup
            modelBuilder.Entity<UserStatusLookup>().Property(p => p.Id).HasColumnName("UserStatusId");
            modelBuilder.Entity<NationalityLookup>().Property(p => p.Id).HasColumnName("NationalityId");
            modelBuilder.Entity<CountryLookup>().Property(p => p.Id).HasColumnName("CountryId");
            modelBuilder.Entity<LanguageLookup>().Property(p => p.Id).HasColumnName("LanguageId");
            modelBuilder.Entity<ServiceCategoryLookup>().Property(p => p.ServiceCategoryId).HasColumnName("ServiceCategoryId");
            modelBuilder.Entity<ServiceSubCategoryLookup>().Property(p => p.ServiceSubCategoryId).HasColumnName("ServiceSubCategoryId");
           // modelBuilder.Entity<SJCESP_LawyerInformation>().Property(p => p.lawyerid).HasConversion("LawyerName");
          //  modelBuilder.Entity<UpdateUsers>().Property(p => p.UserId).HasColumnName("UserId");
            // In OnModelCreating method
            //modelBuilder.Entity<Users>(u =>
            //{
            //    u.ToTable("Users");
            //    u.Property(e => e.UserId).HasColumnName("Id");
            //    // Configuration for other properties
            //});
            //modelBuilder.Entity<UpdateUsers>(u =>
            //{
            //    u.ToTable("Users");
            //    u.Property(e => e.UserId).HasColumnName("UserId");
            //    u.HasOne<Users>().WithOne().HasForeignKey<UpdateUsers>(e => e.UserId);
            //});
            //modelBuilder.Entity<Services>(u =>
            //{
            //    u.ToTable("Services");
            //    u.Property(e => e.ServiceId).HasColumnName("ServiceId");
            //    // Configuration for other properties
            //});
            //modelBuilder.Entity<AddService>(u =>
            //{
            //    u.ToTable("Services");
            //    u.Property(e => e.ServiceId).HasColumnName("ServiceId");
            //    u.HasOne<Services>().WithOne().HasForeignKey<AddService>(e => e.ServiceId);
            //});
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
        public virtual DbSet<UsersProfilePicture> UsersProfilePicture { get; set; }

        public virtual DbSet<UsersProfilePictureView> UsersProfilePictureView { get; set; }

        // public virtual DbSet<UpdateUsers> UpdateUsers { get; set; }

        public DbSet<SJCESP_AlertandNotification> SJCESP_AlertandNotification { get; set; }
        public virtual DbSet<SJCESP_CaseInformation> SJCESP_CaseInformation { get; set; }
        public virtual DbSet<SJCESP_Cases> SJCESP_Cases { get; set; }
        public virtual DbSet<SJCESP_civilno> SJCESP_civilno { get; set; }
        public virtual DbSet<SJCESP_Denominations> SJCESP_Denominations { get; set; }
        public virtual DbSet<SJCESP_Decision> SJCESP_Decision { get; set; }
        public virtual DbSet<SJCESP_Judge_Information> SJCESP_Judge_Information { get; set; }
        public virtual DbSet<SJCESP_LawyerAddress> SJCESP_LawyerAddress { get; set; }
        public virtual DbSet<SJCESP_LawyerCaces> SJCESP_LawyerCaces { get; set; }
        public virtual DbSet<SJCESP_LawyerInformation> SJCESP_LawyerInformation { get; set; }
        public virtual DbSet<SJCESP_RoleParties> SJCESP_RoleParties { get; set; }
        public virtual DbSet<SJCESP_Session_Information> SJCESP_Session_Information { get; set; }

    }
}

