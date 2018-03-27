using Newtonsoft.Json;
using System.Collections.Generic;

namespace CodeSanook.AdministrativeDivision.Models
{
    [JsonObject(MemberSerialization.OptIn)]
    public class DistrictRecord
    {
        [JsonProperty]
        public virtual int Id { get; set; }

        [JsonProperty]
        public virtual int Code { get; set; }

        [JsonProperty]
        public virtual string NameInThai { get; set; }

        [JsonProperty]
        public virtual string NameInEnglish { get; set; }

        public virtual ProvinceRecord ProvinceRecord { get; set; }

        public virtual IList<SubdistrictRecord> SubdistrictRecords { get; set; }

        public DistrictRecord()
        {
            this.SubdistrictRecords = new List<SubdistrictRecord>();
        }
    }
}