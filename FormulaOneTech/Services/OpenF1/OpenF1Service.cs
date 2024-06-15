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

        /// <summary>
        /// Gets the latest meeting key which is the id for a race
        /// </summary>
        /// <param name="additionalParams"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Gets the latest session key which is the id for the race weekend session
        /// </summary>
        /// <param name="additionalParams"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
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


        /// <summary>
        /// Gets race control messages 
        /// </summary>
        /// <param name="additionalParams"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
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

                return raceControl.OrderByDescending(r => r.Date).ToList();
            }
            catch
            {
                return new List<RaceControl>();
            }
            throw new NotImplementedException();
        }

        /// <summary>
        /// Gets driver communication radio from pit wall
        /// </summary>
        /// <param name="additionalParams"></param>
        /// <returns></returns>
        public async Task<List<TeamRadio>> GetDriverRadioAudio(Dictionary<string, string> additionalParams)
        {
            try
            {
                var queryString = BuildQueryString(additionalParams);
                var uribuilder = new UriBuilder(_httpClient.BaseAddress + "team_radio")
                { Query = queryString };

                var response = await _httpClient.GetAsync(uribuilder.ToString());
                var data = await response.Content.ReadAsStringAsync();
                var driverAudio = JsonSerializer.Deserialize<List<TeamRadio>>(data);

                return driverAudio.OrderByDescending(r => r.Date).ToList();
            }
            catch
            {
                return new List<TeamRadio>();
            }
        }

        /// <summary>
        /// Gets a drivers stints which is laps on a specific tyre compound
        /// </summary>
        /// <param name="additionalParams"></param>
        /// <returns></returns>
        public async Task<List<Stints>> GetDriverStints(Dictionary<string, string> additionalParams)
        {
            try
            {
                var queryString = BuildQueryString(additionalParams);
                var uribuilder = new UriBuilder(_httpClient.BaseAddress + "stints")
                { Query = queryString };

                var response = await _httpClient.GetAsync(uribuilder.ToString());
                var data = await response.Content.ReadAsStringAsync();
                var driverStints = JsonSerializer.Deserialize<List<Stints>>(data);

                return driverStints;
            }
            catch
            {
                return new List<Stints>();
            }
        }
    }
}
