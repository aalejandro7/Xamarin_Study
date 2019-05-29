namespace Test.Models
{
    using Newtonsoft.Json;
    using System.Collections.Generic;

    public class ServiceResponse
    {
        [JsonProperty("error")]
        public long Error { get; set; }

        [JsonProperty("total")]
        public long Total { get; set; }

        [JsonProperty("Users")]
        public List<User> Users { get; set; }
    }
}
