using SteamBot.Model;
using SteamBot.Constant;
using Newtonsoft.Json;

namespace SteamBot.Client
{
    public class AppDetailClient
    {
        private HttpClient _client;
        private static string _apiKey;
        private static string _address;
        private string _apiHost;
        public AppDetailClient()
        {
            _client = new HttpClient();
            _address = Constants.localApiAdress;
            _client.BaseAddress = new Uri(_address);
        }
        public async Task<AppDetailModel> GetAppDetailsAsync(int AppId)
        {
            var response = await _client.GetAsync($"/AppDetails?AppId={AppId}");
            var content = response.Content.ReadAsStringAsync().Result;
            var result = JsonConvert.DeserializeObject<AppDetailModel>(content);
            return result;
        }
    }
}
