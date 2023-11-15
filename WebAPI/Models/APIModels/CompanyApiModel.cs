using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace WebAPI.Models.APIModels
{
    public class CompanyApiRequestModel
    {
        public string CompanyNo { get; set; }
    }
    public class Activity
    {
        public string IsicCode { get; set; }
        public double IsicVersion { get; set; }
        public string NameAr { get; set; }
        public string NameEn { get; set; }
        public DateTime RegistrationDate { get; set; }
        public object SubjectToLicensing { get; set; }
        public object LicenseObtained { get; set; }
    }

    public class Activity2
    {
        public Activity Activity { get; set; }
    }

    public class Address
    {
        public Town Town { get; set; }
        public State State { get; set; }
        public Governorate Governorate { get; set; }
        public string PostalCode { get; set; }
        public string PoBox { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
    }

    public class BusinessLocation
    {
        public Town Town { get; set; }
        public State State { get; set; }
        public Governorate Governorate { get; set; }
        public string PostalCode { get; set; }
        public string PoBox { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public string StreetNameAr { get; set; }
        public string StreetNameEn { get; set; }
    }

    public class Capital
    {
        public double CashCapital { get; set; }
        public double AssetCapital { get; set; }
        public double TotalCapital { get; set; }
        public double ShareValue { get; set; }
        public double TotalShares { get; set; }
        public string CapitalVerified { get; set; }
    }

    public class Contact
    {
        public object Phone { get; set; }
        public string Mobile { get; set; }
        public string Email { get; set; }
    }

    public class Country
    {
        public string NameAr { get; set; }
        public string NameEn { get; set; }
        public int Code { get; set; }
        public object Text { get; set; }
    }

    public class DeclaredActivities
    {
        public List<Activity> Activity { get; set; }
    }

    public class Designation
    {
        public string NameAr { get; set; }
        public string NameEn { get; set; }
        public string Code { get; set; }
        public object Text { get; set; }
    }

    public class Fiscal
    {
        public DateTime FirstFiscalYearEnd { get; set; }
        public int FiscalYearEndDay { get; set; }
        public int FiscalYearEndMonth { get; set; }
    }

    public class Governorate
    {
        public string NameAr { get; set; }
        public string NameEn { get; set; }
        public string SpecialZone { get; set; }
        public string Code { get; set; }
        public object Text { get; set; }
    }

    public class Investor
    {
        public string IsEstablishment { get; set; }
        public Designation Designation { get; set; }
        public int NumberOfShares { get; set; }
        public DateTime RegistrationDate { get; set; }
        public Person Person { get; set; }
        public object Company { get; set; }
    }

    public class Investors
    {
        public List<Investor> Investor { get; set; }
    }

    public class IssueCountry
    {
        public string NameAr { get; set; }
        public string NameEn { get; set; }
        public int Code { get; set; }
        public object Text { get; set; }
    }

    public class LegalStatus
    {
        public string NameAr { get; set; }
        public string NameEn { get; set; }
        public string Code { get; set; }
        public object Text { get; set; }
    }
    public class ContractAuthenticator
    {
        public string code { get; set; }
        public string nameAr { get; set; }
        public string nameEn { get; set; }
    }
    public class CoverageType
    {
        public string code { get; set; }
        public string nameAr { get; set; }
        public string nameEn { get; set; }
    }
    public class Mortgage
    {
        public Mortgage mortgage { get; set; }
    }

    public class Mortgage2
    {
        public string contractNumber { get; set; }
        public string contractDate { get; set; }
        public object loanNumber { get; set; }
        public string amount { get; set; }
        public string currency { get; set; }
        public MortgageType mortgageType { get; set; }
        public MortgageGrade mortgageGrade { get; set; }
        public Mortgagee mortgagee { get; set; }
        public string mortgageDuration { get; set; }
        public ContractAuthenticator contractAuthenticator { get; set; }
        public CoverageType coverageType { get; set; }
        public string registrationDate { get; set; }
    }
    public class Company
    {
        public string crNumber { get; set; }
        public string companyNameArabic { get; set; }
        public string companyNameEnglish { get; set; }
        public string companyNameWithLegalArabic { get; set; }
        public string companyNameWithLegalEnglish { get; set; }
        public Country country { get; set; }
        public LegalStatus legalStatus { get; set; }
        public RegistrationStatus registrationStatus { get; set; }
        public string registrationDate { get; set; }
        public string establishmentDate { get; set; }
        public string subjectToForeignInvestment { get; set; }
        public string expiryDate { get; set; }
        public string isExpired { get; set; }
    }
    public class Mortgagee
    {
        public Company company { get; set; }
    }

    public class MortgageGrade
    {
        [JsonProperty("@code")]
        public string code { get; set; }
        public string nameAr { get; set; }
        public string nameEn { get; set; }
    }

    public class MortgageType
    {
        [JsonProperty("@code")]
        public string code { get; set; }
        public string nameAr { get; set; }
        public string nameEn { get; set; }
    }


    public class Nationality
    {
        public string NameAr { get; set; }
        public string NameEn { get; set; }
        public int Code { get; set; }
        public object Text { get; set; }
    }

    public class Passport
    {
        public string Number { get; set; }
        public IssueCountry IssueCountry { get; set; }
        public DateTime IssueDate { get; set; }
    }

    public class Person
    {
        public string IdNumber { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string NameAr { get; set; }
        public string NameEn { get; set; }
        public string Gender { get; set; }
        public Nationality Nationality { get; set; }
    }

    public class PlaceOfActivity
    {
        public string PoaCode { get; set; }
        public BusinessLocation BusinessLocation { get; set; }
        public List<Activity> Activities { get; set; }
    }

    public class PlacesOfActivities
    {
        public List<PlaceOfActivity> PlaceOfActivity { get; set; }
    }

    public class RegistrationStatus
    {
        public string NameAr { get; set; }
        public string NameEn { get; set; }
        public string Code { get; set; }
        public object Text { get; set; }
    }

    public class CompanyApiResponseModel
    {
        public string CrNumber { get; set; }
        public string CompanyNameArabic { get; set; }
        public object CompanyNameEnglish { get; set; }
        public string CompanyNameWithLegalArabic { get; set; }
        public object CompanyNameWithLegalEnglish { get; set; }
        public Country Country { get; set; }
        public LegalStatus LegalStatus { get; set; }
        public RegistrationStatus RegistrationStatus { get; set; }
        public DateTime RegistrationDate { get; set; }
        public DateTime EstablishmentDate { get; set; }
        public string SubjectToForeignInvestment { get; set; }
        public DateTime ExpiryDate { get; set; }
        public string IsExpired { get; set; }
        public Address Address { get; set; }
        public Contact Contact { get; set; }
        public Capital Capital { get; set; }
        public Fiscal Fiscal { get; set; }
        public DeclaredActivities DeclaredActivities { get; set; }
        public PlacesOfActivities PlacesOfActivities { get; set; }
        public Investors Investors { get; set; }
        public Signatories Signatories { get; set; }
        //public List<Mortgage> Mortgages { get; set; }
        public object LegalSubStatus { get; set; }
    }

    public class Signatories
    {
        public List<Signatory> Signatory { get; set; }
    }

    public class Signatory
    {
        public string IdNumber { get; set; }
        public Passport Passport { get; set; }
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
        public SignatureType SignatureType { get; set; }
        public DateTime SignatoryStartDate { get; set; }
    }

    public class SignatureType
    {
        public string NameAr { get; set; }
        public string NameEn { get; set; }
        public string Code { get; set; }
        public object Text { get; set; }
    }

    public class State
    {
        public string NameAr { get; set; }
        public string NameEn { get; set; }
        public string SpecialZone { get; set; }
        public string Code { get; set; }
        public object Text { get; set; }
    }

    public class Town
    {
        public string NameAr { get; set; }
        public string NameEn { get; set; }
        public string SpecialZone { get; set; }
        public string Code { get; set; }
        public object Text { get; set; }
    }
}
