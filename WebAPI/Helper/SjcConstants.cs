using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPI.Models;
using WebAPI.Models.APIModels;

namespace WebAPI.Helper
{
    public static class SjcConstants
    {
        #region Roles
        public const string roleSystemAdmin = "System Admin";
        public const string roleCompanyManager = "Company Manager";
        public const string roleLawyer = "Lawyer";
        public const string roleIndividual = "Individual";
        #endregion
        #region Temporary Methods for dummy responses
        public static HttpResponseModel<MobilePKIResponseModel> getPKIResponse(string mobileNo)
        {
            if (mobileNo == "98034451")
            {
                return new HttpResponseModel<MobilePKIResponseModel>() { data = new List<MobilePKIResponseModel>() { new MobilePKIResponseModel() { CivilNo = "132646232" } } };
            }
            else if (mobileNo == "98034452")
            {
                return new HttpResponseModel<MobilePKIResponseModel>() { data = new List<MobilePKIResponseModel>() { new MobilePKIResponseModel() { CivilNo = "131346369" } } };
            }
            return null;
        }
        public static HttpResponseModel<PersonalApiResponseModel> getPersonalInfo(string civilNo)
        {
            string jsonResponse = "";
            if (civilNo == "132646232")
            {
                jsonResponse = "{\r\n    \"civilNumber\": \"132646232\",\r\n    \"Nationalitycode\": \"PAK\",\r\n    \"Nationalitydesc_en\": \"PAKISTANI\",\r\n    \"Nationalitydesc_ar\": \"باكستاني\",\r\n    \"dateOfBirth\": \"1994-03-10 00:00:00.0\",\r\n    \"Countrycode\": \"PAK\",\r\n    \"Countrydesc_ar\": null,\r\n    \"fullname\": \"محمد انس فريد \",\r\n    \"fullname_en\": \"MUHAMMAD  ANUS FAREED \",\r\n    \"title_ar\": null,\r\n    \"name_1_ar\": null,\r\n    \"name_2_ar\": null,\r\n    \"name_3_ar\": null,\r\n    \"name_4_ar\": null,\r\n    \"name_5_ar\": null,\r\n    \"name_6_ar\": null,\r\n    \"Wilayatcode\": null,\r\n    \"Wilayatdesc_ar\": null,\r\n    \"Towncode\": null,\r\n    \"Towndesc_ar\": null,\r\n    \"passportNumber\": \"CC8976092\",\r\n    \"passportExpireDate\": \"2026-01-17 00:00:00.0\",\r\n    \"passportCountryCode\": \"586\",\r\n    \"visaNumber\": \"143305\",\r\n    \"visaNumberExpirydate\": \"2024-02-10 00:00:00.0\",\r\n    \"mobileNumber\": \"79093825\",\r\n    \"telephoneNumber\": null,\r\n    \"emailAddress\": null,\r\n    \"fullAddress\": \" /  / \",\r\n    \"buildingNumber\": null,\r\n    \"city\": null,\r\n    \"wayNumber\": null,\r\n    \"Gender\": \"1\",\r\n    \"Genderdesc_en\": \"Male\",\r\n    \"Genderdesc_ar\": \"ذكر\",\r\n    \"dateOfDeath\": null,\r\n    \"CurrentAddress\": {\r\n        \"emailAddress\": null,\r\n        \"mobileNumber\": \"79093825\",\r\n        \"telephoneNumber\": null,\r\n        \"buildingNumber\": null,\r\n        \"city\": null,\r\n        \"wayNumber\": null,\r\n        \"governorateDesc_ar\": \"مسقط\",\r\n        \"wilayatDesc_ar\": \"بوشر\",\r\n        \"townDesc_ar\": \"غلأ\"\r\n    },\r\n    \"PermanentAddress\": null,\r\n    \"WorkAddress\": null,\r\n    \"ListRelationVM\": []\r\n}";
                return JsonConvert.DeserializeObject<HttpResponseModel<PersonalApiResponseModel>>(jsonResponse);
            }
            else if (civilNo == "131346369")
            {
                jsonResponse = "{\r\n    \"civilNumber\": \"131346369\",\r\n    \"Nationalitycode\": \"PAK\",\r\n    \"Nationalitydesc_en\": \"PAKISTANI\",\r\n    \"Nationalitydesc_ar\": \"باكستاني\",\r\n    \"dateOfBirth\": \"1994-03-10 00:00:00.0\",\r\n    \"Countrycode\": \"PAK\",\r\n    \"Countrydesc_ar\": null,\r\n    \"fullname\": \"عرفان رفيق\",\r\n    \"fullname_en\": \"IRFAN RAFIQ \",\r\n    \"title_ar\": null,\r\n    \"name_1_ar\": null,\r\n    \"name_2_ar\": null,\r\n    \"name_3_ar\": null,\r\n    \"name_4_ar\": null,\r\n    \"name_5_ar\": null,\r\n    \"name_6_ar\": null,\r\n    \"Wilayatcode\": null,\r\n    \"Wilayatdesc_ar\": null,\r\n    \"Towncode\": null,\r\n    \"Towndesc_ar\": null,\r\n    \"passportNumber\": \"AN1987444\",\r\n    \"passportExpireDate\": \"2032-01-17 00:00:00.0\",\r\n    \"passportCountryCode\": \"586\",\r\n    \"visaNumber\": \"143305\",\r\n    \"visaNumberExpirydate\": \"2024-02-10 00:00:00.0\",\r\n    \"mobileNumber\": \"79093825\",\r\n    \"telephoneNumber\": null,\r\n    \"emailAddress\": null,\r\n    \"fullAddress\": \" /  / \",\r\n    \"buildingNumber\": null,\r\n    \"city\": null,\r\n    \"wayNumber\": null,\r\n    \"Gender\": \"1\",\r\n    \"Genderdesc_en\": \"Male\",\r\n    \"Genderdesc_ar\": \"ذكر\",\r\n    \"dateOfDeath\": null,\r\n    \"CurrentAddress\": {\r\n        \"emailAddress\": null,\r\n        \"mobileNumber\": \"79093825\",\r\n        \"telephoneNumber\": null,\r\n        \"buildingNumber\": null,\r\n        \"city\": null,\r\n        \"wayNumber\": null,\r\n        \"governorateDesc_ar\": \"مسقط\",\r\n        \"wilayatDesc_ar\": \"بوشر\",\r\n        \"townDesc_ar\": \"غلأ\"\r\n    },\r\n    \"PermanentAddress\": null,\r\n    \"WorkAddress\": null,\r\n    \"ListRelationVM\": []\r\n}";
                return JsonConvert.DeserializeObject<HttpResponseModel<PersonalApiResponseModel>>(jsonResponse);
            }
            return null;
        }
        #endregion 
    }
}
