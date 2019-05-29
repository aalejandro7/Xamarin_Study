namespace Test.Models
{
    using Newtonsoft.Json;
    using System;

    public class User
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("surname")]
        public string Surname { get; set; }

        [JsonProperty("telephone ")]
        public string Telephone { get; set; }


    }
}
