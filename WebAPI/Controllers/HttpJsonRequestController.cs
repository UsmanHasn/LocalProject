using Azure;
using Data.Interface;
using Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Net;
using System.Reflection;
using System.Reflection.Metadata;
using System.Security.Cryptography;
using System.Xml.Linq;
using WebAPI.Helper;
using WebAPI.Models;
using WebAPI.Models.APIModels;
using static Azure.Core.HttpHeader;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/httpjson/")]
    public class HttpJsonRequestController : Controller
    {
        private readonly IRepository<Users> _userRepository;

        public HttpJsonRequestController(IRepository<Users> userRepository)
        {
            _userRepository = userRepository;
        }
        [HttpPost]
        [Route("getpersonalinfo")]
        public async Task<IActionResult> GetPersonalInfo(PersonalApiRequestModel personalApiRequest)
        {
            HttpClientHelper httpClientHelper = new HttpClientHelper();
            var response = new PersonalApiResponseModel();
            try
            {
                //Get Personal Information
                var responseString = await httpClientHelper.MakeHttpRequestJsonString<PersonalApiRequestModel, PersonalApiResponseModel>
                    ("http://sjcintgerationsvc/api/GovServ/PersonInformationV2/" + personalApiRequest.CardCivilNo + "/" + personalApiRequest.cardExpiryDate, HttpMethod.Get, null, null);
                HttpStringResponseModel httpStringResponse = JsonConvert.DeserializeObject<HttpStringResponseModel>(responseString);
                response = JsonConvert.DeserializeObject<PersonalApiResponseModel>(httpStringResponse.data);

            }
            catch (Exception ex)
            {
                return null;                
            }
            if (response != null)
            {
                /*
                    here we will call Expert api and check if it is expert then insert into experts
                    http://sjcintgerationsvc/api/GovServ/getExpertInformation/personalApiRequest.CardCivilNo
                    this api returns placecode which will pass to instituteapi and get all lawyer in that institute we will insert all these lawyers
                    http://sjcintgerationsvc/api/GovServ/InstitutionInformation?code={371}
                */
                SqlParameter[] parameters = new SqlParameter[33]
                {
                    new SqlParameter("UserName", response.fullname_en),
                    new SqlParameter("UserNameAr", response.fullname),
                    new SqlParameter("CivilNumber", response.civilNumber),
                    new SqlParameter("CivilExpiryDate", personalApiRequest.cardExpiryDate),
                    new SqlParameter("Nationalitycode", response.Nationalitycode),
                    new SqlParameter("Nationalitydesc_en", response.Nationalitydesc_en),
                    new SqlParameter("Nationalitydesc_ar", response.Nationalitydesc_ar),
                    new SqlParameter("DateOfBirth", response.dateOfBirth),
                    new SqlParameter("CountryCode", response.passportCountryCode),
                    new SqlParameter("Countrydesc_ar", response.Countrydesc_ar),
                    new SqlParameter("title_ar", response.title_ar),
                    new SqlParameter("name_1_ar", response.name_1_ar),
                    new SqlParameter("name_2_ar", response.name_2_ar),
                    new SqlParameter("name_3_ar", response.name_3_ar),
                    new SqlParameter("name_4_ar", response.name_4_ar),
                    new SqlParameter("name_5_ar", response.name_5_ar),
                    new SqlParameter("name_6_ar", response.name_6_ar),
                    new SqlParameter("Wilayatcode", response.Wilayatcode),
                    new SqlParameter("Wilayatdesc_ar", response.Wilayatdesc_ar),
                    new SqlParameter("Towncode", response.Towncode),
                    new SqlParameter("Towndesc_ar", response.Towndesc_ar),
                    new SqlParameter("PassportNumber", response.passportNumber),
                    new SqlParameter("PassportExpiryDate", response.passportExpireDate),
                    new SqlParameter("VisaNumber", response.visaNumber),
                    new SqlParameter("VisaExpiryDate", response.visaNumberExpirydate),
                    new SqlParameter("DateofDeath", response.dateOfDeath),
                    new SqlParameter("Email", personalApiRequest.email),
                    new SqlParameter("BuildingNumber", response.buildingNumber),
                    new SqlParameter("City", response.city),
                    new SqlParameter("WayNumber", response.wayNumber),
                    new SqlParameter("PhoneNumber", response.mobileNumber),
                    new SqlParameter("TelephoneNumber", response.telephoneNumber),
                    new SqlParameter("Gender", response.Gender)
                };
                try
                {
                    Console.WriteLine(parameters);
                    _userRepository.ExecuteStoredProcedure("UpsertUsers", parameters);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }

                //Get Lawyer Info
                string lawyerWorkPlaceCode = await LawyerInfo_UpsertLawyer(personalApiRequest.CardCivilNo, personalApiRequest.email);
            }
            return new JsonResult(new { data = (response != null ? response : null), status = HttpStatusCode.OK });
        }
        [HttpGet]
        [Route("getlawyerbycivilno")]
        public async Task<IActionResult> GetLawyerByCivilNo(string civilNo)
        {
            HttpClientHelper httpClientHelper = new HttpClientHelper();
            var responseLaywer = await httpClientHelper.MakeHttpRequest<HttpResponseModel<LawyerJsonModel>, HttpResponseModel<LawyerJsonModel>>("http://10.146.2.5/WBSTest/api/GovServ/LawyerInformation/" + civilNo, HttpMethod.Get, null, null);
            var response = new List<LawyerJsonModel>();
            response.AddRange(responseLaywer.data);
            return new JsonResult(new { data = response, status = HttpStatusCode.OK });
        }
        private async Task<string> LawyerInfo_UpsertLawyer(string civilNo, string email)
        {
            HttpClientHelper httpClientHelper = new HttpClientHelper();
            var responseLawyerString = await httpClientHelper.MakeHttpRequestJsonString<string, string>
                ("http://sjcintgerationsvc/api/GovServ/LawyerInformation/" + civilNo, HttpMethod.Get, null, null);
            HttpStringResponseModel httpStringResponse = JsonConvert.DeserializeObject<HttpStringResponseModel>(responseLawyerString);
            LawyerApiResponseModel responseLawyer = JsonConvert.DeserializeObject<LawyerApiResponseModel>(httpStringResponse.data);
            if (httpStringResponse.data != null && responseLawyer != null && !string.IsNullOrEmpty(responseLawyer.lawyerCivilNO))
            {
                //Add/Update Institute first
                if (!string.IsNullOrEmpty(responseLawyer.lawyerWorkPlaceCode))
                {
                    await InstituteInfo_UpsertInstitute(responseLawyer.lawyerWorkPlaceCode);
                }
                
                // Create an array of SqlParameter objects
                SqlParameter[] parametersLawyer = new SqlParameter[]
                {
                        new SqlParameter("@CivilNO", responseLawyer.lawyerCivilNO),
                        new SqlParameter("@NameAr", responseLawyer.lawyerNameArabic),
                        new SqlParameter("@NameEn", responseLawyer.lawyerNameEnglish),
                        new SqlParameter("@Email", email),
                        new SqlParameter("@Gender", responseLawyer.lawyerGender),
                        new SqlParameter("@Mobile", responseLawyer.lawyerMobile),
                        new SqlParameter("@Nationality", responseLawyer.lawyerNationality),
                        new SqlParameter("@AddressRegion", responseLawyer.lawyerAddressRegion),
                        new SqlParameter("@AddressState", responseLawyer.lawyerAddressState),
                        new SqlParameter("@LandLine", responseLawyer.lawyerLandLine),
                        new SqlParameter("@ClassCode", responseLawyer.lawyerClassCode),
                        new SqlParameter("@ClassName", responseLawyer.lawyerClassName),
                        new SqlParameter("@FileNo", responseLawyer.lawyerFileNo),
                        new SqlParameter("@LicenseEndDate", responseLawyer.lawyerLicenseEndDate),
                        new SqlParameter("@LicenseStartDate", responseLawyer.lawyerLicenseStartDate),
                        new SqlParameter("@RegistrtionNO", responseLawyer.lawyerRegistrtionNO),
                        new SqlParameter("@Status", responseLawyer.lawyerStatus),
                        new SqlParameter("@StatusCode", responseLawyer.lawyerStatusCode),
                        new SqlParameter("@WorkPlace", responseLawyer.lawyerWorkPlace),
                        new SqlParameter("@WorkPlaceCode", responseLawyer.lawyerWorkPlaceCode),
                        new SqlParameter("@WorkPlaceEmail", responseLawyer.lawyerWorkPlaceEmail),
                        new SqlParameter("@WorkPlaceMobile", responseLawyer.lawyerWorkPlaceMobile),
                        new SqlParameter("@WorkPlaceRegion", responseLawyer.lawyerWorkPlaceRegion),
                        new SqlParameter("@WorkPlaceState", responseLawyer.lawyerWorkPlaceState),
                        new SqlParameter("@ArabicName", responseLawyer.lawyerArabicName),
                        new SqlParameter("@EnglishName", responseLawyer.lawyerEnglishName),
                        new SqlParameter("@OwnerArabicName", responseLawyer.ownerArabicName),
                        new SqlParameter("@OwnerCivilNo", responseLawyer.ownerCivilNo),
                        new SqlParameter("@OwnerEnglishName", responseLawyer.ownerEnglishName),
                        new SqlParameter("@OwnerFileNo", responseLawyer.ownerFileNo),
                        new SqlParameter("@OwnerGender", responseLawyer.ownerGender),
                        new SqlParameter("@OwnerNationality", responseLawyer.ownerNationality),
                        new SqlParameter("@PartnerType", responseLawyer.partnerType),
                        new SqlParameter("@SignRight", responseLawyer.signRight),
                        new SqlParameter("@InstitutionLicenseEndDate", responseLawyer.institutionLicenseEndDate),
                        new SqlParameter("@InstitutionLicenseStartDate", responseLawyer.institutionLicenseStartDate),
                        new SqlParameter("@InstitutionRegDate", responseLawyer.institutionRegDate),
                        new SqlParameter("@InstitutionRegNo", responseLawyer.institutionRegNo),
                        new SqlParameter("@InstitutionStatus", responseLawyer.institutionStatus),
                };
                try
                {
                    _userRepository.ExecuteStoredProcedure("UpsertLawyer", parametersLawyer);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
            }
            return responseLawyer.lawyerWorkPlaceCode;
        }
        private async Task InstituteInfo_UpsertInstitute(string workplaceCode)
        {
            HttpClientHelper httpClientHelper = new HttpClientHelper();
            var responseInstituteString = await httpClientHelper.MakeHttpRequestJsonString<string, string>
                ("http://sjcintgerationsvc/api/GovServ/InstitutionInformation/" + workplaceCode, HttpMethod.Get, null, null);
            HttpStringResponseModel httpStringResponse = JsonConvert.DeserializeObject<HttpStringResponseModel>(responseInstituteString);
            InstituteApiModel responseInstitute = JsonConvert.DeserializeObject<InstituteApiModel>(httpStringResponse.data);
            BodyObject instituteBody = responseInstitute.Body;
            ReturnData responseData = instituteBody.getInstitutionInformationResponse.Return;
            List<InstitutionInfo> instituteList = responseData.ListinstitutionInfo;
            foreach (InstitutionInfo institutionInfo in instituteList)
            {
                SqlParameter[] parametersInstitute = new SqlParameter[]
                {
                    new SqlParameter("Code", institutionInfo.institutionCode),
                    new SqlParameter("Email", institutionInfo.institutionEmail),
                    new SqlParameter("MobileNo", institutionInfo.institutionMobileNo),
                    new SqlParameter("Name", institutionInfo.institutionName),
                    new SqlParameter("Region", institutionInfo.institutionRegin),
                    new SqlParameter("State", institutionInfo.institutionState),
                    new SqlParameter("LicenseStartDate", institutionInfo.institutionRegistrationInfo.institutionLicenseStartDate),
                    new SqlParameter("LicenseEndDate", institutionInfo.institutionRegistrationInfo.institutionLicenseEndDate),
                    new SqlParameter("RegDate", institutionInfo.institutionRegistrationInfo.institutionRegDate),
                    new SqlParameter("RegNo", institutionInfo.institutionRegistrationInfo.institutionRegNo),
                    new SqlParameter("Status", institutionInfo.institutionRegistrationInfo.institutionStatus)
                };
                try
                {
                    _userRepository.ExecuteStoredProcedure("UpsertInstitute", parametersInstitute);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
                var OwnerInfo = institutionInfo.institutionOwnersInfo;
                SqlParameter[] parametersOwner = new SqlParameter[]
                {
                    new SqlParameter("@WorkPlaceCode", workplaceCode),
                    new SqlParameter("@CivilNo", OwnerInfo.ownerCivilNo),
                    new SqlParameter("@NameEn", OwnerInfo.ownerEnglishName),
                    new SqlParameter("@NameAr", OwnerInfo.ownerArabicName),
                    new SqlParameter("@FileNo", OwnerInfo.ownerFileNo),
                    new SqlParameter("@Gender", OwnerInfo.ownerGender),
                    new SqlParameter("@Nationality", OwnerInfo.ownerNationality),
                    new SqlParameter("@PartnerType", OwnerInfo.partnerType),
                    new SqlParameter("@SignRight", OwnerInfo.signRight)
                };
                try
                {
                    _userRepository.ExecuteStoredProcedure("UpsertInstituteOwner", parametersOwner);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
                var ListofLawyerInfo = institutionInfo.ListinstitutionLawyersInfo;

                foreach (LawyerInfo responseLawyer in ListofLawyerInfo)
                {
                    SqlParameter[] parametersLawyer = new SqlParameter[]
                {
                        new SqlParameter("@CivilNO", responseLawyer.lawyerCivilNO),
                        new SqlParameter("@NameAr", responseLawyer.lawyerArabicName),
                        new SqlParameter("@NameEn", responseLawyer.lawyerEnglishName),
                        new SqlParameter("@Email", responseLawyer.lawyerEmail),
                        new SqlParameter("@Gender", responseLawyer.lawyerGender),
                        new SqlParameter("@Mobile", responseLawyer.lawyerMobile),
                        new SqlParameter("@Nationality", responseLawyer.lawyerNationality),
                        new SqlParameter("@AddressRegion", DBNull.Value),
                        new SqlParameter("@AddressState", DBNull.Value),
                        new SqlParameter("@LandLine", DBNull.Value),
                        new SqlParameter("@ClassCode", responseLawyer.lawyerClassCode),
                        new SqlParameter("@ClassName", responseLawyer.lawyerClassName),
                        new SqlParameter("@FileNo", responseLawyer.lawyerFileNo),
                        new SqlParameter("@LicenseEndDate", DBNull.Value),
                        new SqlParameter("@LicenseStartDate", DBNull.Value),
                        new SqlParameter("@RegistrtionNO", DBNull.Value),
                        new SqlParameter("@Status", responseLawyer.lawyerStatus),
                        new SqlParameter("@StatusCode", responseLawyer.lawyerStatusCode),
                        new SqlParameter("@WorkPlace",instituteList[0].institutionName),
                        new SqlParameter("@WorkPlaceCode", instituteList[0].institutionCode),
                        new SqlParameter("@WorkPlaceEmail", instituteList[0].institutionEmail),
                        new SqlParameter("@WorkPlaceMobile", instituteList[0].institutionMobileNo),
                        new SqlParameter("@WorkPlaceRegion", instituteList[0].institutionRegin),
                        new SqlParameter("@WorkPlaceState", instituteList[0].institutionState),
                        new SqlParameter("@ArabicName", responseLawyer.lawyerArabicName),
                        new SqlParameter("@EnglishName", responseLawyer.lawyerEnglishName),
                        new SqlParameter("@OwnerArabicName", instituteList[0].institutionOwnersInfo.ownerArabicName),
                        new SqlParameter("@OwnerCivilNo", instituteList[0].institutionOwnersInfo.ownerCivilNo),
                        new SqlParameter("@OwnerEnglishName", instituteList[0].institutionOwnersInfo.ownerEnglishName),
                        new SqlParameter("@OwnerFileNo", instituteList[0].institutionOwnersInfo.ownerFileNo),
                        new SqlParameter("@OwnerGender", instituteList[0].institutionOwnersInfo.ownerGender),
                        new SqlParameter("@OwnerNationality", instituteList[0].institutionOwnersInfo.ownerNationality),
                        new SqlParameter("@PartnerType", DBNull.Value),
                        new SqlParameter("@SignRight", DBNull.Value),
                        new SqlParameter("@InstitutionLicenseEndDate", DBNull.Value),
                        new SqlParameter("@InstitutionLicenseStartDate", DBNull.Value),
                        new SqlParameter("@InstitutionRegDate", DBNull.Value),
                        new SqlParameter("@InstitutionRegNo", DBNull.Value),
                        new SqlParameter("@InstitutionStatus", DBNull.Value),
                };
                    try
                    {
                        _userRepository.ExecuteStoredProcedure("UpsertLawyer", parametersLawyer);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex);
                    }
                }

            }
        }

    }
}
