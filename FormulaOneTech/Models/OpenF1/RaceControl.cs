using System.Text.Json.Serialization;

namespace FormulaOneTech.Models.OpenF1
{
    public class RaceControl
    {
        [JsonPropertyName("category")]
        public string? Category { get; set; }

        [JsonPropertyName("date")]
        public DateTime? Date { get; set; }

        [JsonPropertyName("driver_number")]
        public int? DriverNumber { get; set; }

        [JsonPropertyName("flag")]
        public string? Flag { get; set; }

        [JsonPropertyName("lap_number")]
        public int? LapNumber { get; set; }

        [JsonPropertyName("meeting_key")]
        public int? MeetingKey { get; set; }

        [JsonPropertyName("message")]
        public string? Message { get; set; }

        [JsonPropertyName("scope")]
        public string? Scope { get; set; }

        [JsonPropertyName("sector")]
        public int? Sector { get; set; }

        [JsonPropertyName("session_key")]
        public int? SessionKey { get; set; }
    }
}
