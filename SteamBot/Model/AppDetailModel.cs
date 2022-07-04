using Newtonsoft.Json;

namespace SteamBot.Model
{
    public class AppDetailModel
    {
        public string imgUrl { get; set; }
        public string title { get; set; }
        public Developer developer { get; set; }
        public Publisher publisher { get; set; }
        public string released { get; set; }
        public string description { get; set; }
        public List<Tag> tags { get; set; }
        public AllReviews allReviews { get; set; }
        public string price { get; set; }
        [JsonProperty("DLCs")]
        public List<Dlc> DLCs { get; set; }


    }
    public class Developer
    {
        public string link { get; set; }
        public string name { get; set; }
    }
    public class Publisher
    {
        public string link { get; set; }
        public string name { get; set; }
    }
    public class Tag
    {
        public string url { get; set; }
        public string name { get; set; }
    }
    public class AllReviews
    {
        public string summary { get; set; }
        [JsonProperty("reviewCount")]
        public int reviewCount { get; set; }
        [JsonProperty("ratingValue")]
        public int ratingValue { get; set; }
        [JsonProperty("bestRating")]
        public int bestRating { get; set; }
        [JsonProperty("worstRating")]
        public int worstRating { get; set; }
    }
    public class Dlc
    {
        [JsonProperty("appId")]
        public int appId { get; set; }
        [JsonProperty("url")]
        public string url { get; set; }
        [JsonProperty("name")]
        public string name { get; set; }
        [JsonProperty("price")]
        public string price { get; set; }
    }
}
