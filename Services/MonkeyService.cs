using System.Net.Http.Json;

namespace monkeys.Services
{
    public class MonkeyService
    {
        HttpClient httpClient;
        public MonkeyService()
        {
            httpClient = new HttpClient();
        }

        List<Monkey> monkeys = new();
        public async Task<List<Monkey>> GetMonkeys()
        {
            if (monkeys?.Count > 0)
                return monkeys;

            var url = "https://montemagno.com/monkeys.json";

            var response = await httpClient.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                monkeys = await response.Content.ReadFromJsonAsync<List<Monkey>>();
            }

            return monkeys;
        }
    }
}
