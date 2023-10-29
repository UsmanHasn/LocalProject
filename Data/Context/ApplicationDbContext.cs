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
            modelBuilder.Entity<SEC_Roles>().Property(p => p.Id).HasColumnName("RoleId");
            modelBuilder.Entity<SEC_Users>().Property(p => p.Id).HasColumnName("UserId");
            modelBuilder.Entity<SYS_Menu>().Property(p => p.Id).HasColumnName("MenuId");
            modelBuilder.Entity<SEC_UserInRole>().Property(p => p.Id).HasColumnName("UserRoleId");
            modelBuilder.Entity<SEC_UserActivityInfoLog>().Property(p => p.UserId).HasColumnName("UserId");
            modelBuilder.Entity<SYS_Services>().Property(p => p.ServiceSubCategoryId).HasColumnName("ServiceId");
            modelBuilder.Entity<SYS_Pages>().Property(p => p.Id).HasColumnName("PageId");
            modelBuilder.Entity<SEC_RolePermissions>().Property(p => p.Id).HasColumnName("RolePermissionId");
            modelBuilder.Entity<SEC_UserDelegatedPermissions>().Property(p => p.Id).HasColumnName("UserPermissionId");
            modelBuilder.Entity<SYS_SystemSettings>().Property(p => p.Id).HasColumnName("SystemSettingId");
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
            modelBuilder.Entity<SEC_UserStatusLookup>().Property(p => p.Id).HasColumnName("UserStatusId");
            modelBuilder.Entity<LKT_Nationality>().Property(p => p.Id).HasColumnName("NationalityId");
            modelBuilder.Entity<LKT_Country>().Property(p => p.Id).HasColumnName("CountryId");
            modelBuilder.Entity<SYS_Language>().Property(p => p.Id).HasColumnName("LanguageId");
            modelBuilder.Entity<SYS_ServiceCategory>().Property(p => p.ServiceCategoryId).HasColumnName("ServiceCategoryId");
            modelBuilder.Entity<SYS_ServiceSubCategory>().Property(p => p.ServiceSubCategoryId).HasColumnName("ServiceSubCategoryId");
            modelBuilder.Entity<SEC_UsersProfilePicture>().Property(p => p.UserId).HasColumnName("UserId");
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
        public DbSet<SEC_Roles> SEC_Roles { get; set; }
        public DbSet<SEC_Users> SEC_Users { get; set; }
        public DbSet<SEC_UserStatusLookup> SEC_UserStatusLookup { get; set; }
        public DbSet<SEC_UserInRole> SEC_UserInRole { get; set; }
        public DbSet<SEC_UserActivityInfoLog> SEC_UserActivityInfoLog { get; set; }
        public DbSet<SYS_Menu> SYS_Menu { get; set; }
        public DbSet<SYS_Services> SYS_Services { get; set; }
        public DbSet<SYS_Pages> SYS_Pages { get; set; }
        public DbSet<SEC_RolePermissions> SEC_RolePermissions { get; set; }
        public DbSet<SEC_UserDelegatedPermissions> SEC_UserDelegatedPermissions { get; set; }
        public DbSet<SYS_SystemSettings> SYS_SystemSettings { get; set; }
        //Lookup
        public DbSet<LKT_Nationality> LKT_Nationality { get; set; }
        public DbSet<LKT_Country> LKT_Country { get; set; }
        public DbSet<SYS_Language> SYS_Language { get; set; }
        public DbSet<SYS_ServiceCategory> SYS_ServiceCategory { get; set; }
        public DbSet<SYS_ServiceSubCategory> SYS_ServiceSubCategory { get; set; }
        public virtual DbSet<SEC_UsersProfilePicture> SEC_UsersProfilePicture { get; set; }

        public virtual DbSet<UsersProfilePictureView> UsersProfilePictureView { get; set; }
        public virtual DbSet<DwonloadUsersProfilePicture> DwonloadUsersProfilePicture { get; set; }

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

