namespace Service.Models
{
    public class CaseGroupModel
    {
        public int CaseGroupId { get; set; }
        public string CAAJ_Code { get; set; }
        public string ACO_Code { get; set; }
        public string NameEn { get; set; }
        public string NameAr { get; set; }
        public bool? IsActive { get; set; }
        public string CreatedBy { get; set; }
    }
    public class CaseGroupCategoryModel
    {
        public int CaseCategoryId { get; set; }
        public int CaseGroupId { get; set; }
        public string CAAJ_Code { get; set; }
        public string ACO_Code { get; set; }
        public string NameEn { get; set; }
        public string NameAr { get; set; }
        public bool? IsActive { get; set; }
        public string CreatedBy { get; set; }
    }
    public class CaseGroupCountValues
    {
        public int CaseGroupId { get; set; }
        public int Governorates { get; set; }
        public int Buildings { get; set; }
        public int CaseCategory { get; set;}
        public int CaseTypes { get; set; }
        public int CaseSubjects { get; set; }
    }
    public class LKTGovernorateModel
    {
        public int GovernateId { get; set; }
        public string Code { get; set; }
        public string NameEn { get; set; }
        public string NameAr { get; set; }
        public bool? IsActive { get; set; }
        public string CreatedBy { get; set; }
    }
    public class LKTLocationModel
    {
        public int LocationId { get; set; }
        public int GovernateId { get; set; }
        public string Code { get; set; }
        public string NameEn { get; set; }
        public string NameAr { get; set; }
        public string LinkLocationId { get; set; }
        public bool? IsActive { get; set; }
        public string CreatedBy { get; set; }
    }
    public class GovernoratesModel
    {
        public int GrpGovernateId { get; set; }
        public int CaseGroupId { get; set; }
        public int GovernateId { get; set; }
        public string NameEn { get; set; }
        public string NameAr { get; set; }
    }
    public class LKT_GroupGovernoratesModel
    {
        public int CaseGroupId { get; set; }
        public int[] GovernorateId { get; set; }
        public string CreatedBy { get; set; }
    }
    public class LocationModel
    {
        public int CaseGroupId { get; set; }
        public int LocationId { get; set; }
        public int LinkLocationId { get; set; }
        public int GovernateId { get; set; }
        public string Code { get; set; }
        public string NameEn { get; set; }
        public string NameAr { get; set; }
        public bool IsActive { get; set; }
    }
    public class GroupGovrenorateLocationModel
    {
        public int CaseGroupId { get; set; }
        public int GrpGovernateId { get; set; }
        public int LocationId { get; set; }
        public string CaseGroupAr { get; set; }
        public string CaseGroupEn { get; set; }
        public string GovernoratesAr { get; set; }
        public string GovernoratesEn { get; set; }
        public string LocationAr { get; set; }
        public string LocationEn { get; set; }
    }
    public class treeViewGrpGovernLocModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string TitleEn { get; set; }
        public List<treeViewGrpGovernLocModel> Children { get; set; }
        public int? Parent { get; set; }
        public int Level { get; set; }
    }
    public class CaseCategoryGroupModel
    {
        public int CaseGroupId { get; set; }
        public int GovernateId { get; set; }
        public int LocationId { get; set; }
        public string CaseGroupEn { get; set; }
        public string CaseGroupAr { get; set; }
        public int CaseCategoryId { get; set; }
        public string CAAJ_Code { get; set; }
        public string ACO_Code { get; set; }
        public string CaseCategoryAr { get; set; }
        public string CaseCategoryEn { get; set; }
        public string RequestLinkSource { get; set; }
        public bool IsActive { get; set; }
    }
    public class CaseCategoryTypesModel
    {
        public int CaseTypeId { get; set; }
        public string CAAJ_Code { get; set; }
        public string ACO_Code { get; set; }
        public string NameEn { get; set; }
        public string NameAr { get; set; }
        public int? FirstPartyTypeId { get; set; }
        public int? SecondPartyTypeId { get; set; }
        public bool? IsActive { get; set; }
        public string? CreatedBy { get; set; }
        public bool? AllowLinkCase { get; set; }
    }
    public class COR_GroupCatTypeModel
    {
        public int CaseGroupId { get; set; }
        public int CaseCategoryId { get; set; }
        public int[] CaseTypeId { get; set; }
        public string CreatedBy { get; set; }
    }
}
