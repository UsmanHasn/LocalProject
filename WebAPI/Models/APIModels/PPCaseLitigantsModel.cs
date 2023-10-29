namespace WebAPI.Models.APIModels
{
    public class PPCaseLitigantsModel
    {
        public string opp_casecode { get; set; }
        public List<CaseLitigant> Case_Litigants { get; set; }
    }
    public class CaseLitigant
    {
        public string p_case_org_cr { get; set; }
        public string p_org_name { get; set; }
        public int p_litigant_org_per { get; set; }
        public string p_a_f_name { get; set; }
        public string p_a_s_name { get; set; }
        public string p_a_t_name { get; set; }
        public string p_a_tribe_name { get; set; }
        public int p_country_code { get; set; }
        public string p_id_card_number { get; set; }
        public string P_PRESENT_ADDRESS { get; set; }
        public string p_present_phone { get; set; }
        public string p_passport_number { get; set; }
        public string p_person_code { get; set; }
        public int p_litigant_type { get; set; }
        public string litigantRole { get; set; }
        public object BirthDate { get; set; }
        public int p_id_Type { get; set; }
        public string p_full_name { get; set; }
    }
    public class PPCaseLitigantsApiRequestModel
    {
        public string CaseNo { get; set; }
    }
}
