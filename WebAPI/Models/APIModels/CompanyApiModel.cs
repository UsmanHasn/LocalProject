using System;
using System.Collections.Generic;

namespace WebAPI.Models.APIModels
{
    public class CompanyApiRequestModel
    {
        public string CompanyNo { get; set; }
    }
    public class Nationality
    {
        public string NameAr { get; set; }
        public string NameEn { get; set; }
        public string Code { get; set; }
    }

    public class Designation
    {
        public string NameAr { get; set; }
        public string NameEn { get; set; }
        public string Code { get; set; }
    }

    public class SignatureType
    {
        public string NameAr { get; set; }
        public string NameEn { get; set; }
        public string Code { get; set; }
    }
    public class Signatories { 
    public Signatory Signatory { get; set; }
    }
    public class Signatory
    {
        public string IdNumber { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string NameAr { get; set; }
        public string NameEn { get; set; }
        public string Gender { get; set; }
        public Nationality Nationality { get; set; }
        public Designation Designation { get; set; }
        public string HasFullAuthority { get; set; }
        public string HasTechnicalAuthority { get; set; }
        public string HasFinancialAuthority { get; set; }
        public string HasAdministrativeAuthority { get; set; }
        public object AuthorizationLimit { get; set; }
        public SignatureType SignatureType { get; set; }
        public DateTime SignatoryStartDate { get; set; }
    }

    public class CompanyApiResponseModel
    {
        public string crNumber { get; set; }
        public string companyNameArabic { get; set; }
        public string companyNameEnglish { get; set; }
        public string companyNameWithLegalArabic { get; set; }
        public string companyNameWithLegalEnglish { get; set; }
        public string country { get; set; }
        public string registrationStatus { get; set; }
        public DateTime registrationDate { get; set; }
        public DateTime establishmentDate { get; set; }
        public string subjectToForeignInvestment { get; set; }
        public DateTime expiryDate { get; set; }
        public string expiryDatestr { get; set; }
        public string isExpired { get; set; }
        public string contact { get; set; }
        public string address { get; set; }
        public string legalStatus { get; set; }
        public string mobile { get; set; }
        public string phone { get; set; }
        public string fax { get; set; }
        public string email { get; set; }
        public string legalname { get; set; }
        public string town { get; set; }
        public string region { get; set; }
        public string government { get; set; }
        public string Signatories { get; set; }
        public string governmentEntityCode { get; set; }
    }

}
