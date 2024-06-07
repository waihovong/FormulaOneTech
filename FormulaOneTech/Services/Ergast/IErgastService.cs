using FormulaOneTech.Models.Ergast;

namespace FormulaOneTech.Services.Ergast
{
    public interface IErgastService
    {
        Task<List<Driver>> GetDrivers(string year);
        Task<List<DriverStandings>> GetCurrentDriverStandings();
    }
}
