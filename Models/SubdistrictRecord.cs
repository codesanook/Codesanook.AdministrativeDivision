using Newtonsoft.Json;

namespace Codesanook.AdministrativeDivision.Models
{
    [JsonObject(MemberSerialization.OptIn)]
    public class SubdistrictRecord
    {
        [JsonProperty]
        public virtual int Id { get; set; }

        [JsonProperty]
        public virtual int Code { get; set; }

        [JsonProperty]
        public virtual string NameInThai { get; set; }

        [JsonProperty]
        public virtual string NameInEnglish { get; set; }

        [JsonProperty]
        public virtual decimal Latitude { get; set; }

        [JsonProperty]
        public virtual decimal Longitude { get; set; }

        [JsonProperty]
        public virtual int ZipCode { get; set; }

        public virtual DistrictRecord District { get; set; }
    }
}