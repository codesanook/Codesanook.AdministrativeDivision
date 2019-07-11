using Newtonsoft.Json;
using System.Collections.Generic;

namespace Codesanook.AdministrativeDivision.Models
{
    [JsonObject(MemberSerialization.OptIn)]
    public class ProvinceRecord
    {
        [JsonProperty]
        public virtual int Id { get; set; }

        [JsonProperty]
        public virtual int Code { get; set; }

        [JsonProperty]
        public virtual string NameInThai { get; set; }

        [JsonProperty]
        public virtual string NameInEnglish { get; set; }

        public virtual IList<DistrictRecord> Districts { get; set; }

        public ProvinceRecord()
        {
            Districts = new List<DistrictRecord>();
        } 
    }
}