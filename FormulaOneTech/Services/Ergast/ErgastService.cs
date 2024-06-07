using FormulaOneTech.Models.Ergast;
using System.Text.Json;
using FormulaOneTech.Helpers;
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
                var driverStandings = results?.MRData?.StandingsTable?.StandingsLists?
                    .SelectMany(s => s.DriverStandings)
                    .Select(d => new DriverStandings
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

        public async Task<List<ConstructorStandings>> GetConstructorStandings()
        {
            var response = await _httpClient.GetAsync("current/constructorStandings.json");

            if (response.IsSuccessStatusCode)
            {
                var data = await response.Content.ReadAsStringAsync();

                var results = JsonSerializer.Deserialize<ErgastRootModel>(data, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });

                var constructorStandings = results?.MRData?.StandingsTable?.StandingsLists?
                    .SelectMany(c => c.ConstructorStandings)
                    .Select(t => new ConstructorStandings
                    {
                        Points = t.Points,
                        Wins = t.Wins,
                        Position = t.Position,
                        Constructor = t.Constructor,
                    }).ToList();

                return constructorStandings ?? new List<ConstructorStandings>();
            }

            return new List<ConstructorStandings>();
        }

        public async Task<List<Race>> GetCurrentSeason()
        {
            var response = await _httpClient.GetAsync("current.json");

            if (response.IsSuccessStatusCode)
            {
                var data = await response.Content.ReadAsStringAsync();

                var results = JsonSerializer.Deserialize<ErgastRootModel>(data, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });

                var currentSeason = results?.MRData?.RaceTable?.Races?.
                    Select(r => new Race
                    {
                        Circuit = r.Circuit,
                        FirstPractice = r.FirstPractice,
                        SecondPractice = r.SecondPractice,
                        ThirdPractice = r.ThirdPractice,
                        Qualifying = r.Qualifying,
                        Date = r.Date,
                        Time = r.Time,
                        RaceName = r.RaceName,
                        Round = r.Round,
                        Season = r.Season,
                        Sprint = r.Sprint
                    }).ToList();

                return currentSeason ?? new List<Race>();
            }
            return new List<Race>();
        }

        public async Task<RaceMapper.RaceDto> GetNextRace()
        {
            var response = await _httpClient.GetAsync("current/next.json");

            if (response.IsSuccessStatusCode)
            {
                var data = await response.Content.ReadAsStringAsync();

                var results = JsonSerializer.Deserialize<ErgastRootModel>(data, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });

                var nextRace = results?.MRData?.RaceTable?.Races
                    .Select(r => new Race
                    {
                        Circuit = r.Circuit,
                        FirstPractice = r.FirstPractice,
                        SecondPractice = r.SecondPractice,
                        ThirdPractice = r.ThirdPractice,
                        Qualifying = r.Qualifying,
                        Date = r.Date,
                        Time = r.Time,
                        RaceName = r.RaceName,
                        Round = r.Round,
                        Season = r.Season,
                        Sprint = r.Sprint
                    }).FirstOrDefault();

                if (nextRace != null)
                {
                    return RaceMapper.RaceMapDto(nextRace) ;
                }
            }
            return new RaceMapper.RaceDto();
        }

        public static DateTime ConvertLocal(DateTime? utcTime, TimeZoneInfo localTimeZone)
        {
            return TimeZoneInfo.ConvertTimeToUtc(utcTime.Value, localTimeZone);
        }


        //todo have another function that will get the next race here and do all the stuff here
        //http://ergast.com/api/f1/current/last/results.json
    }
}
