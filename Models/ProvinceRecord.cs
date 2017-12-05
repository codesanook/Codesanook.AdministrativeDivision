using System.Collections.Generic;

namespace CodeSanook.AdministrativeDivision.Models
{
    public class ProvinceRecord
    {
        public virtual int Id { get; set; }
        public virtual int Code { get; set; }
        public virtual string NameInThai { get; set; }
        public virtual string NameInEnglish { get; set; }
        public virtual IList<DistrictRecord> DistrictRecords { get; set; }

        public ProvinceRecord()
        {
            DistrictRecords = new List<DistrictRecord>();
        } 
    }
}