
namespace Test.Models
{
    using System;
    using Newtonsoft.Json;

    public class TokenResponse
    {
        #region Properties
        [JsonProperty(PropertyName = "success")]
        public DateTime Issued { get; set; }

        [JsonProperty(PropertyName = "authToken")]
        public string AccessToken { get; set; }
        
        [JsonProperty(PropertyName = "email")]
        public string Email { get; set; }

        [JsonProperty(PropertyName = "zone")]
        public string Zone { get; set; }
        #endregion

        #region Methods

        #endregion
    }
}