using FormulaOneTech.Models.OpenF1;

namespace FormulaOneTech.Services.OpenF1
{
    public interface IOpenF1Service
    {
        Task<List<Meeting>> GetLatestMeetingKey(Dictionary<string,string> additionalParams);
        Task<List<Session>> GetSessionKey(Dictionary<string, string> additionalParams);
        Task<List<RaceControl>> GetRaceControlData(Dictionary<string, string> additionalParams);
        Task<List<TeamRadio>> GetDriverRadioAudio(Dictionary<string, string> additionalParams);
    }
}
