using Newtonsoft.Json;

namespace SteamBot.Model
{
    public class AppReviewsModel
    {
        [JsonProperty("query_summary")]
        public QuerySummary query_summary { get; set; }
        [JsonProperty("reviews")]
        public List<Review> reviews { get; set; }
    }
    public class QuerySummary
    {
        [JsonProperty("num_reviews")]
        public int num_reviews { get; set; }
        [JsonProperty("review_score")]
        public int review_score { get; set; }
        [JsonProperty("review_score_desc")]
        public string review_score_desc { get; set; }
        [JsonProperty("total_positive")]
        public int total_positive { get; set; }
        [JsonProperty("total_negative")]
        public int total_negative { get; set; }
        [JsonProperty("total_reviews")]
        public int total_reviews { get; set; }
    }
    public class Author
    {
        [JsonProperty("steamid")]
        public long steamid { get; set; }
        [JsonProperty("num_games_owned")]
        public int num_games_owned { get; set; }

    }
    public class Review
    {
        [JsonProperty("recommendationid")]
        public int recommendationid { get; set; }
        [JsonProperty("author")]
        public Author author { get; set; }
        [JsonProperty("review")]
        public string review { get; set; }
    }
}
