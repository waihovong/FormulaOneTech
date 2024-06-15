using System.Text.Json.Serialization;

namespace FormulaOneTech.Models.OpenF1
{
    public class Meeting
    {
        [JsonPropertyName("circuit_key")]
        public int? CircuitKey { get; set; }

        [JsonPropertyName("circuit_short_name")]
        public string? CircuitShortName { get; set; }

        [JsonPropertyName("country_code")]
        public string? CountryCode { get; set; }

        [JsonPropertyName("country_key")]
        public int? CountryKey { get; set; }

        [JsonPropertyName("country_name")]
        public string? CountryName { get; set; }

        [JsonPropertyName("date_start")]
        public DateTime? DateStart { get; set; }

        [JsonPropertyName("gmt_offset")]
        public string? GmtOffset { get; set; }

        [JsonPropertyName("location")]
        public string? Location { get; set; }

        /// <summary>
        /// Meeting key is the key to the race
        /// </summary>
        [JsonPropertyName("meeting_key")]
        public int? MeetingKey { get; set; }

        [JsonPropertyName("meeting_name")]
        public string? MeetingName { get; set; }

        [JsonPropertyName("meeting_official_name")]
        public string? MeetingOfficialName { get; set; }

        [JsonPropertyName("year")]
        public int? Year { get; set; }
    }
}
