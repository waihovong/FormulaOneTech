using FormulaOneTech.Models.Ergast;
using System.Text.Json;
using FormulaOneTech.Helpers;
namespace FormulaOneTech.Services.Ergast
{
    public class ErgastService : IErgastService
    {
        private readonly HttpClient _httpClient;

        private const int API_LIMIT = 80; //API allows maximum of 1000 limit, but advises to use least amount
        public ErgastService (HttpClient httpClient)
        {
            _httpClient = httpClient;

        }

        /// <summary>
        /// Gets all the drivers in a particular year
        /// </summary>
        /// <param name="year"></param>
        /// <returns></returns>
        public async Task<List<Driver>> GetDrivers(string year = "current")
        {
            var response = await _httpClient.GetAsync($"{year}/drivers.json");

            var data = await response.Content.ReadAsStringAsync();

            var results = JsonSerializer.Deserialize<ErgastRootModel>(data, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });

            var currentDrivers = results?.MRData?.DriverTable.Drivers
                .Select(r => new Driver
                {
                    PermanentNumber = r.PermanentNumber,
                    Code = r.Code,
                    DateOfBirth = r.DateOfBirth,
                    DriverId = r.DriverId,
                    FamilyName = r.FamilyName,
                    GivenName = r.GivenName,
                    Nationality = r.Nationality
                }).ToList();

            return currentDrivers ?? new List<Driver>();
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

        
        public async Task<RaceMapper.RaceDto> GetPreviousRaceResults()
        {
            var response = await _httpClient.GetAsync("current/last/results.json");

            if (response.IsSuccessStatusCode)
            {
                var data = await response.Content.ReadAsStringAsync();

                var results = JsonSerializer.Deserialize<ErgastRootModel>(data, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });

                var previousResults = results?.MRData?.RaceTable?.Races?
                    .Select(r => new Race()
                    {
                        Round = r.Round,
                        Circuit = r.Circuit,
                        Season = r.Season,
                        Date = r.Date,
                        Time = r.Time,
                        Results = r.Results,
                        RaceName = r.RaceName,

                    }).FirstOrDefault();

                if (previousResults != null)
                {
                    return RaceMapper.RaceMapDto(previousResults);
                }
            }
            return new RaceMapper.RaceDto();
        }

        public async Task<RaceMapper.RaceDto> GetPreviousQualiResults(string year, string round)
        {
            var response = await _httpClient.GetAsync($"{year}/{round}/qualifying.json");

            if (response.IsSuccessStatusCode)
            {
                var data = await response.Content.ReadAsStringAsync();

                var results = JsonSerializer.Deserialize<ErgastRootModel>(data, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });

                var qualiResults = results?.MRData?.RaceTable?.Races?
                    .Select(r => new Race
                    {
                        QualifyingResults = r.QualifyingResults
                    }).FirstOrDefault();
                if (qualiResults != null)
                {
                    return RaceMapper.RaceMapDto(qualiResults);
                }
            }
            return new RaceMapper.RaceDto();

        }

        public async Task<RaceMapper.LapIntervalDto> GetSelectedDriverRacePace(string driverCode, string season, string round)
        {

            var response = await _httpClient.GetAsync($"{season}/{round}/drivers/{driverCode}/laps.json?limit={API_LIMIT}");

            if(response.IsSuccessStatusCode)
            {
                var data = await response.Content.ReadAsStringAsync();

                var results = JsonSerializer.Deserialize<ErgastRootModel>(data, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });

                var driver = results?.MRData?.RaceTable?.Races?
                    .Select(r => new Race
                    {
                        Laps = r.Laps
                    }).ToList();

                if (driver != null && driver.Count() > 0)
                {
                    return RaceMapper.LapMapDto(driver.FirstOrDefault()?.Laps);
                }
            }
            return new RaceMapper.LapIntervalDto();
        }
    }
}
