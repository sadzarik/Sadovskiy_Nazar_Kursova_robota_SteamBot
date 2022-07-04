using Newtonsoft.Json;

namespace SteamBot.Model
{
    public class SteamAppInfo
    {
        [JsonProperty("appId")]
        public int appId { get; set; }
        [JsonProperty("title")]
        public string title { get; set; }
        [JsonProperty("url")]
        public string url { get; set; }
        [JsonProperty("imgUrl")]
        public string imgUrl { get; set; }
        [JsonProperty("released")]
        public string released { get; set; }
        [JsonProperty("reviewSummary")]
        public string reviewSummary { get; set; }
        [JsonProperty("price")]
        public string price { get; set; }

    }
}


