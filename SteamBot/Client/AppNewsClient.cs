using SteamBot.Constant;
using SteamBot.Model;
using Newtonsoft.Json;

namespace SteamBot.Client
{
    public class AppNewsClient
    {
        private HttpClient _client;
        private static string _address;
        public AppNewsClient()
        {
            _client = new HttpClient();
            _address = Constants.localApiAdress;
            _client.BaseAddress = new Uri(_address);
        }
        public async Task<AppNewsModel> GetAppNewsAsync(int AppId)
        {
            var response = await _client.GetAsync($"/AppNews?AppId={AppId}");
            var content = response.Content.ReadAsStringAsync().Result;
            var result = JsonConvert.DeserializeObject<AppNewsModel>(content);
            return result;
        }
    }
}
