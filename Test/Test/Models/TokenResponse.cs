namespace Test.Models
{
    using Newtonsoft.Json;

    public class TokenResponse
    {
        #region Properties
        [JsonProperty("success")]
        public bool Success { get; set; }

        [JsonProperty("authToken")]
        public string AuthToken { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }
        #endregion
    }
}