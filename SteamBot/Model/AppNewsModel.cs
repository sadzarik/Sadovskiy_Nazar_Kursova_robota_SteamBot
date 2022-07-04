using Newtonsoft.Json;

namespace SteamBot.Model
{
    public class AppNewsModel
    {
        [JsonProperty("appnews")]
        public SteamAppNews appnews { get; set; }
    }
    public class SteamAppNews
    {
        [JsonProperty("appid")]
        public int appid { get; set; }
        [JsonProperty("newsitems")]
        public List<SteamAppNewsItem> newsitems { get; set; }
        [JsonProperty("count")]
        public int count { get; set; }
    }
    public class SteamAppNewsItem
    {
        [JsonProperty("gid")]
        public string gid { get; set; }
        [JsonProperty("title")]
        public string title { get; set; }
        [JsonProperty("url")]
        public string url { get; set; }
        [JsonProperty("author")]
        public string author { get; set; }
        [JsonProperty("contents")]
        public string contents { get; set; }
        [JsonProperty("appid")]
        public int appid { get; set; }
    }
}
