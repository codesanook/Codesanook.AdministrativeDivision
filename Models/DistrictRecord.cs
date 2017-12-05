namespace CodeSanook.AdministrativeDivision.Models
{
    public class DistrictRecord
    {
        public virtual int Id { get; set; }
        public virtual int Code { get; set; }
        public virtual string NameInThai { get; set; }
        public virtual string NameInEnglish { get; set; }
        public virtual ProvinceRecord ProvinceRecord { get; set; }
    }
}