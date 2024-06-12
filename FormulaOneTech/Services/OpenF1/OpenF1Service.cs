using FormulaOneTech.Models.OpenF1;
using FormulaOneTech.Services.Ergast;
using System.Text.Json;
using System.Web;

namespace FormulaOneTech.Services.OpenF1
{
    public class OpenF1Service : IOpenF1Service
    {
        private readonly HttpClient _httpClient;

        public OpenF1Service (HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        /// <summary>
        /// Gets the latest race meeting key, latest will also be getting the updated race live
        /// </summary>
        /// <returns></returns>
        private string BuildQueryString(Dictionary<string, string> parameters)
        {
            var query = HttpUtility.ParseQueryString(string.Empty);
            foreach (var param in parameters)
            {
                query[param.Key] = param.Value;
            }
            return query.ToString();
        }
        public async Task<List<Meeting>> GetLatestMeetingKey(Dictionary<string, string> additionalParams)
        {
            try
            {
                var queryString = BuildQueryString(additionalParams);

                var uriBuilder = new UriBuilder(_httpClient.BaseAddress + "meetings")
                {
                    Query = queryString
                };

                var reponse = await _httpClient.GetAsync(uriBuilder.ToString());

                var data = await reponse.Content.ReadAsStringAsync();

                var meeting = JsonSerializer.Deserialize<List<Meeting>>(data , new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true,
                });

                return meeting;
            }
            catch
            {
                return new List<Meeting>();
            }
        }


        public async Task<List<Session>> GetSessionKey(Dictionary<string, string> additionalParams)
        {
            try
            {
                var queryString = BuildQueryString(additionalParams);
                var uribuilder = new UriBuilder(_httpClient.BaseAddress + "sessions")
                { Query = queryString };

                var response = await _httpClient.GetAsync(uribuilder.ToString());
                var data = await response.Content.ReadAsStringAsync();
                var session = JsonSerializer.Deserialize<List<Session>>(data);

                return session;
            }
            catch
            {
                return new List<Session>();
            }

            throw new NotImplementedException();
        }

        public async Task<List<RaceControl>> GetRaceControlData(Dictionary<string, string> additionalParams)
        {
            try
            {
                var queryString = BuildQueryString(additionalParams);
                var uribuilder = new UriBuilder(_httpClient.BaseAddress + "race_control")
                { Query = queryString };

                var response = await _httpClient.GetAsync(uribuilder.ToString());
                var data = await response.Content.ReadAsStringAsync();
                var raceControl = JsonSerializer.Deserialize<List<RaceControl>>(data);

                return raceControl;
            }
            catch
            {
                return new List<RaceControl>();
            }
            //https://api.openf1.org/v1/race_control?date=2024-06-09
            throw new NotImplementedException();
        }
    }
}
