using System.Collections.Generic;
namespace WebAPI.Models.APIModels
{

    // DataObject class to represent the "data" property
    public class InstituteApiModel
    {
        public BodyObject Body { get; set; }
        public object Soapenv { get; set; }
    }

    // BodyObject class to represent the "Body" property
    public class BodyObject
    {
        //public GetLawyerInformationResponse getLawyerInformationResponse { get; set; }
        public GetInstitutionInformationResponse getInstitutionInformationResponse { get; set; }
    }

    // GetInstitutionInformationResponse class to represent the "getInstitutionInformationResponse" property
    public class GetInstitutionInformationResponse
    {
        public ReturnData Return { get; set; }
    }

    // ReturnData class to represent the "Return" property
    public class ReturnData
    {
        public object lawyerInfo { get; set; }
        public List<InstitutionInfo> ListinstitutionInfo { get; set; }
    }

    // InstitutionInfo class to represent the items in "ListinstitutionInfo" array
    public class InstitutionInfo
    {
        public string institutionCode { get; set; }
        public string institutionEmail { get; set; }
        public string institutionMobileNo { get; set; }
        public string institutionName { get; set; }
        public string institutionRegin { get; set; }
        public string institutionState { get; set; }
        public string institutionType { get; set; }
        public List<LawyerInfo> ListinstitutionLawyersInfo { get; set; }
        public InstitutionRegistrationInfo institutionRegistrationInfo { get; set; }
        public InstitutionOwnersInfo institutionOwnersInfo { get; set; }
    }

    // LawyerInfo class to represent the items in "ListinstitutionLawyersInfo" array
    public class LawyerInfo
    {
        public string lawyerArabicName { get; set; }
        public string lawyerCivilNO { get; set; }
        public string lawyerClassCode { get; set; }
        public string lawyerClassName { get; set; }
        public string lawyerEmail { get; set; }
        public string lawyerEnglishName { get; set; }
        public string lawyerFileNo { get; set; }
        public string lawyerGender { get; set; }
        public string lawyerMobile { get; set; }
        public string lawyerNationality { get; set; }
        public string lawyerStatus { get; set; }
        public string lawyerStatusCode { get; set; }
    }

    // InstitutionRegistrationInfo class to represent the "institutionRegistrationInfo" property
    public class InstitutionRegistrationInfo
    {
        public DateTime? institutionLicenseEndDate { get; set; }
        public DateTime? institutionLicenseStartDate { get; set; }
        public string institutionRegDate { get; set; }
        public string institutionRegNo { get; set; }
        public string institutionStatus { get; set; }
    }

    // InstitutionOwnersInfo class to represent the "institutionOwnersInfo" property
    public class InstitutionOwnersInfo
    {
        public string ownerArabicName { get; set; }
        public string ownerCivilNo { get; set; }
        public string ownerEnglishName { get; set; }
        public string ownerFileNo { get; set; }
        public string ownerGender { get; set; }
        public string ownerNationality { get; set; }
        public string partnerType { get; set; }
        public string signRight { get; set; }
    }
}
