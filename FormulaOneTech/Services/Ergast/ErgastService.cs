using FormulaOneTech.Models.Ergast;
using System.Text.Json;

namespace FormulaOneTech.Services.Ergast
{
    public class ErgastService : IErgastService
    {
        private readonly HttpClient _httpClient;

        public ErgastService (HttpClient httpClient)
        {
            _httpClient = httpClient;

        }

        /// <summary>
        /// Gets all the drivers in a particular year
        /// </summary>
        /// <param name="year"></param>
        /// <returns></returns>
        public async Task<List<Driver>> GetDrivers(string year)
        {
            var response = await _httpClient.GetAsync($"{year}/drivers.json");

            var data = await response.Content.ReadAsStringAsync();

            var drivers = JsonSerializer.Deserialize<List<Driver>>(data);

            return drivers;
        }

        /// <summary>
        /// Gets the current seasons drivers standings updated per race
        /// </summary>
        /// <returns></returns>
        public async Task<List<DriverStandings>> GetCurrentDriverStandings()
        {
            var response = await _httpClient.GetAsync("current/driverStandings.json");

            if (response.IsSuccessStatusCode)
            {

            var data = await response.Content.ReadAsStringAsync();

            var results = JsonSerializer.Deserialize<ErgastRootModel>(data, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });

            //todo later map to a function?
            var driverStandings = results?.MRData?.StandingsTable?.StandingsLists?.
                SelectMany(s => s.DriverStandings).
                Select(d => new DriverStandings
                {
                    Constructors = d.Constructors,
                    Points = d.Points,
                    Position = d.Position,
                    Wins = d.Wins,
                    Driver = d.Driver
                }).ToList();

                return driverStandings ?? new List<DriverStandings>();
            }

            return new List<DriverStandings>();
        }
    }
}
