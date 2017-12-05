namespace CodeSanook.AdministrativeDivision.Models
{
    public class SubdistrictRecord
    {
        public virtual int Id { get; set; }
        public virtual int Code { get; set; }
        public virtual string NameInThai { get; set; }
        public virtual string NameInEnglish { get; set; }
        public virtual decimal Latitude { get; set; }
        public virtual decimal Longitude { get; set; }
        public virtual DistrictRecord DistrictRecord { get; set; }
        public virtual int ZipCode { get; set; }
    }
}