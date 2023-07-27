using Domain.Entities.Lookups;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Net.Http;

namespace Domain.Entities
{
    public class Users : BaseEntity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string UserName { get; set; }
        public string UserNameAr { get; set; }
        public string Password { get; set; }
        public string CivilNumber { get; set; }
        public NationalityLookup Nationality { get; set; }
        public int? NationalityId { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public CountryLookup Country { get; set; }
        public int? CountryId { get; set;}
        public string? PassportNumber { get; set; }
        public DateTime? PassportExpiryDate { get; set; }
        public CountryLookup PassportCountry { get; set; }
        public int? PassportCountryId { get; set; }
        public string? VisaNumber { get;set; }
        public DateTime? VisaExpiryDate { get; set; }
        public DateTime? DateofDeath { get; set; }
        [MaxLength(256)]
        public string Email { get; set; }
        [MaxLength(250)]
        public string? BuildingNumber { get; set; }
        [MaxLength(50)]
        public string? City { get; set; }
        [MaxLength(20)]
        public string? WayNumber { get; set; }
        [MaxLength(50)]
        public string? PhoneNumber { get; set; }
        [MaxLength(50)]
        public string? TelephoneNumber { get; set; }
        public string? Gender { get; set; }
        public DateTime? LastLoginDate { get; set; }
        public bool IsLocked { get; set; }
        public DateTime? LockedDate { get; set; }
        public int? WrongPassword { get; set; }
        public int? UserStatusId { get; set; }
        public UserStatusLookup UserStatus { get; set; }
        public int? SupervisorUserId { get; set; }
        public Users SupervisorUser { get; set; }
        public string? title_ar { get; set; }
        public string? name_1_ar { get; set; }
        public string? name_2_ar { get; set; }
        public string? name_3_ar { get; set; }
        public string? name_4_ar { get; set; }
        public string? name_5_ar { get; set; }
        public string? name_6_ar { get; set; }
        public string? Wilayatcode { get; set; }
        public string? Wilayatdesc_ar { get; set; }
        public string? Towncode { get; set; }
        public string? Towndesc_ar { get; set; }
        public DateTime? CivilExpiryDate { get; set; }
        public bool? isEmailVerified { get; set; }
        public bool? isPhoneVerified { get; set; }
    }
}
