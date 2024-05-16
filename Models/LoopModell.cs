using Newtonsoft.Json;

namespace lychee.Models
{
    public class LoopModell
    {
        [JsonProperty("id")]
        public string id { get; set; }
        [JsonProperty("name")]
        public string name { get; set; }
         [JsonProperty("url")]
        public string url { get; set; }

    }
}
