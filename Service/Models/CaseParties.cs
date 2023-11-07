namespace Service.Models
{
    public class CaseParties
    {
        public int CasePartyId { get; set; }
        public int CaseId { get; set; }
        public int PartyNo { get; set; }
        public string? PartyType { get; set; }
        public string? LegalType { get; set; }
        public bool? LinkCaseParty { get; set; }
        public string? PartyTypeAdjective { get; set; }
        public int PartyCategoryId { get; set; }
        public string? PartyCatName { get; set; }
        public int PartyTypeId { get; set; }
        public string? PartyTypeName { get; set; }
        public string? partyTypeNameAr { get; set; }
        public int? EntityId { get; set; }
        public string? EntityName { get; set; }
        public string? EntityNameAr { get; set; }
        public string? CivilNo { get; set; }
        public DateTime? CivilExpiry { get; set; }
        public string? CRNo { get; set; }
        public string? Name { get; set; }
        public string? PhoneNo { get; set; }
        public string? Address { get; set; }

        public string? FamilyName { get; set; }
        public string? Email { get; set; }
        public string? Country { get; set; }
        public string? City { get; set; }
        public int IsDeleted { get; set; }

        public string? DocEn { get; set; }
        public string? DocAr { get; set; }
        public string? DocumentPath { get; set; }
        public string? Description { get; set; }

        public string? FirstName { get; set; }
        public string? MiddleName { get; set; }
        public string? LastName { get; set; }
        public string? FourthName { get; set; }
        public int? CountryId { get; set; }
        public int? GovernorateId { get; set; }
        public int? WilayaId { get; set; }
        public int? VillageId { get; set; }
        public int? AddressTypeId { get; set; }
        public string? WayNo { get; set; }
        public string? AddressLine1 { get; set; }
        public string? AddressLine2 { get; set; }
        public string? CompanyName { get; set; }
        public string? AddressNo { get; set; }
        public string? BuildingNo { get; set; }
    }

    public class CasePartiesDelete
    {
        public int CasePartyId { get; set; }
    }
    public class CasePartiesResponse
    {
        public string msg { get; set; }
        public int status { get; set; }
    }
}