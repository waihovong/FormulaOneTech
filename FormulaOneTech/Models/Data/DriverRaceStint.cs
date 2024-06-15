using FormulaOneTech.Models.Ergast;
using FormulaOneTech.Models.OpenF1;

namespace FormulaOneTech.Models.Data
{
    public class DriverRaceStint
    {
        public Driver Driver { get; set; }
        public List<Stints> Stints { get; set; }
    }
}
