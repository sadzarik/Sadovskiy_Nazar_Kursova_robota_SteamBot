using Newtonsoft.Json;
using SteamBot.Model;
using SteamBot.Constant;
namespace SteamBot.Client
{
    public class SearchAppClient
    {
        private HttpClient _client;
        private static string _address;
        //private static string _apiHost;
        //private static string _apiKey;
        public SearchAppClient()
        {
            _address = Constants.localApiAdress;
            _client = new HttpClient();
            _client.BaseAddress = new Uri(_address);
            //_apiKey = Constants.apiKey;
            //_apiHost = Constants.apiHost;
        }
        public async Task<List<SteamAppInfo>> GetAppInfoAsync(string Name)
        {

            var response = await _client.GetAsync($"SteamAppSearch?AppName={Name}");
            var content = response.Content.ReadAsStringAsync().Result;
            var result = JsonConvert.DeserializeObject<List<SteamAppInfo>>(content);
            return result;
        }
    }
}

