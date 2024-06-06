using FormulaOneTech.Models.Ergast;
using System.Text.Json;

namespace FormulaOneTech.Services.Ergast
{
    public class ErgastService
    {
        private readonly HttpClient _httpClient;

        public ErgastService (HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<Driver>> GetDrivers(string year)
        {
            var response = await _httpClient.GetAsync($"/2024/drivers.json");

            var data = await response.Content.ReadAsStringAsync();

            var drivers = JsonSerializer.Deserialize<List<Driver>>(data);

            return drivers;
        }
    }
}
