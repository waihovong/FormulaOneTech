using FormulaOneTech.Models.Ergast;

namespace FormulaOneTech.Services.Ergast
{
    public interface IErgastService
    {
        Task<List<Driver>> GetDrivers(string year);
        Task<List<DriverStandings>> GetCurrentDriverStandings();
        Task<List<ConstructorStandings>> GetConstructorStandings();
        Task<List<Race>> GetCurrentSeason();
        Task<RaceMapper.RaceDto> GetNextRace();
        Task<RaceMapper.RaceDto> GetPreviousRaceResults();
        Task<RaceMapper.RaceDto> GetPreviousQualiResults(string year, string round);
    }
}
