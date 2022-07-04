using SteamBot.Constant;
using SteamBot.Model;
using Newtonsoft.Json;

namespace SteamBot.Client
{
    public class AppReviewsClient
    {
        private HttpClient _client;
        private static string _address;

        public AppReviewsClient()
        {
            _client = new HttpClient();
            _address = Constants.localApiAdress;
            _client.BaseAddress = new Uri(_address);    
        }
        public async Task<AppReviewsModel> GetAppReviewsAsync(int AppId, int CountOfReviews)
        {
            var response = await _client.GetAsync($"/AppReview?AppId={AppId}&CountOfReviews={CountOfReviews}");
            var content = response.Content.ReadAsStringAsync().Result;
            var result = JsonConvert.DeserializeObject<AppReviewsModel>(content);
            return result;
        }
    }
}
