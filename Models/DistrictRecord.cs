using Newtonsoft.Json;
using System.Collections.Generic;

namespace Codesanook.AdministrativeDivision.Models
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

        public virtual ProvinceRecord Province { get; set; }

        public virtual IList<SubdistrictRecord> Subdistricts { get; set; }

        public DistrictRecord() => Subdistricts = new List<SubdistrictRecord>();
    }
}