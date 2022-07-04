using SteamBot.Constant;
using SteamBot.Model;
using Newtonsoft.Json;

namespace SteamBot.Client
{
    public class GlobalAchievementClient
    {
        private HttpClient _client;
        private static string _apiKey;
        private static string _address;
        private string _apiHost;
        public GlobalAchievementClient()
        {
            _client = new HttpClient();
            _address = Constants.localApiAdress;
            _client.BaseAddress = new Uri(_address);
        }
        public async Task<GlobalAchievementsModel> GetGlobalAchievementsAsync(int AppId)
        {
            var response = await _client.GetAsync($"/GlobalAchievement?AppId={AppId}");
            var content = response.Content.ReadAsStringAsync().Result;
            var result = JsonConvert.DeserializeObject<GlobalAchievementsModel>(content);
            return result;
        }
    }
}
