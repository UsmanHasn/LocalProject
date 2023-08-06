using Microsoft.Identity.Client;
using static WebAPI.Models.APIModels.PersonalApiRequestModel;

namespace WebAPI.Models.APIModels
{
    public class InovokeMobilePKIRequestModel 
    {
        public string Mobile { get; set; }
    }
    public class InovokeMobilePKIResponseModel
    {
        public string CivilNo { get; set; }
    }
    public class PersonalApiRequestModel
    {
        public string CardCivilNo { get; set; }
        public string cardExpiryDate { get; set; }
        public string email { get; set; }
    }
    public class PersonalApiResponseModel
    {
        public string civilNumber { get; set; }
        public string Nationalitycode { get; set; }
        public string Nationalitydesc_en { get; set; }
        public string Nationalitydesc_ar { get; set; }
        public DateTime? dateOfBirth { get; set; }
        public string Countrycode { get; set; }
        public string Countrydesc_ar { get; set; }
        public string fullname { get; set; }
        public string fullname_en { get; set; }
        public string title_ar { get; set; }
        public string name_1_ar { get; set; }
        public string name_2_ar { get; set; }
        public string name_3_ar { get; set; }
        public string name_4_ar { get; set; }
        public string name_5_ar { get; set; }
        public string name_6_ar { get; set; }
        public string Wilayatcode { get; set; }
        public string Wilayatdesc_ar { get; set; }
        public string Towncode { get; set; }
        public string Towndesc_ar { get; set; }
        public string passportNumber { get; set; }
        public string passportExpireDate { get; set; }
        public string passportCountryCode { get; set; }
        public string visaNumber { get; set; }
        public DateTime? visaNumberExpirydate { get; set; }
        public string mobileNumber { get; set; }
        public string telephoneNumber { get; set; }
        public string emailAddress { get; set; }
        public string fullAddress { get; set; }
        public string buildingNumber { get; set; }
        public string city { get; set; }
        public string wayNumber { get; set; }
        public string Gender { get; set; }
        public string Genderdesc_en { get; set; }
        public string Genderdesc_ar { get; set; }
        public DateTime? dateOfDeath { get; set; }
        public CurrentAddress CurrentAddress { get; set; }
        public string PermanentAddress { get; set; }
        public string WorkAddress { get; set; }
        public List<object> ListRelationVM { get; set; }
    }
    public class CurrentAddress
    {
        public object emailAddress { get; set; }
        public string mobileNumber { get; set; }
        public object telephoneNumber { get; set; }
        public object buildingNumber { get; set; }
        public object city { get; set; }
        public object wayNumber { get; set; }
        public string governorateDesc_ar { get; set; }
        public string wilayatDesc_ar { get; set; }
        public string townDesc_ar { get; set; }
    }
}
