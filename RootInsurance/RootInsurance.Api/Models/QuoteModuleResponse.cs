using Newtonsoft.Json;

namespace RootInsurance.Api.Models
{
    public class QuoteModuleResponse
    {
        [JsonProperty("type")]
        public string Type { get; set; }
        [JsonProperty("make")]
        public string Make { get; set; }
        [JsonProperty("model")]
        public string Model { get; set; }
    }
}
