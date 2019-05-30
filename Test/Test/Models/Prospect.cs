namespace Test.Models
{
    using Newtonsoft.Json;
    using System;

    public class Prospect
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("surname")]
        public string Surname { get; set; }

        [JsonProperty("telephone")]
        public string Telephone { get; set; }

        [JsonProperty("schProspectIdentification")]
        public string SchProspectIdentification { get; set; }

        [JsonProperty("address")]
        public string Address { get; set; }

        [JsonProperty("createdAt")]
        public DateTime CreatedAt { get; set; }

        [JsonProperty("updatedAt")]
        public DateTime UpdatedAt { get; set; }

        [JsonProperty("statusCd")]
        public int StatusCd { get; set; }

        [JsonProperty("zoneCode")]
        public int ZoneCode { get; set; }

        [JsonProperty("neighborhoodCode")]
        public string NeighborhoodCode { get; set; }

        [JsonProperty("cityCode")]
        public string CityCode { get; set; }

        [JsonProperty("sectionCode")]
        public string SectionCode { get; set; }

        [JsonProperty("roleId")]
        public int RoleId { get; set; }

        [JsonProperty("appointableId")]
        public object AppointableId { get; set; }

        [JsonProperty("rejectedObservation")]
        public object RejectedObservation { get; set; }

        [JsonProperty("observation")]
        public string Observation { get; set; }

        [JsonProperty("disable")]
        public bool Disable { get; set; }

        [JsonProperty("visited")]
        public bool Visited { get; set; }

        [JsonProperty("callcenter")]
        public bool Callcenter { get; set; }

        [JsonProperty("acceptSearch")]
        public bool AcceptSearch { get; set; }

        [JsonProperty("campaignCode")]
        public int CampaignCode { get; set; }

        [JsonProperty("userId")]
        public object UserId { get; set; }

        public string FullName { get { return $"{this.Name} {this.Surname}"; }  }
    }
}