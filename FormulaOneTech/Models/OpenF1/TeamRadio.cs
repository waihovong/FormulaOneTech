using System.Text.Json.Serialization;

namespace FormulaOneTech.Models.OpenF1
{
    public class TeamRadio
    {
        [JsonPropertyName("date")]
        public DateTime? Date { get; set; }
        [JsonPropertyName("driver_number")]
        public int? DriverNumber { get; set; }
        [JsonPropertyName("meeting_key")]
        public int? MeetingKey { get; set; }
        [JsonPropertyName("session_key")]
        public int? SessionKey { get; set; }
        [JsonPropertyName("recording_url")]
        public string? RecordingUrl { get; set; }
    }
}
