using Microsoft.AspNetCore.Server.Kestrel.Core.Features;

namespace FormulaOneTech.Models.Ergast
{
    public class ErgastRootModel
    {
        public MRData MRData { get; set; }
    }
    
    public class MRData
    {
        public StandingsTable StandingsTable { get; set; }
        public RaceTable RaceTable { get; set; }
        public DriverTable DriverTable { get; set; }
    }

    public class RaceTable
    {
        public string Season { get; set; }
        public List<Race> Races { get; set; }
    }

    public class DriverTable
    {
        public string Season { get; set; }
        public List<Driver> Drivers { get; set; }
    }

    public class StandingsTable
    {
        public string Season { get; set; }
        public List<StandingsList> StandingsLists { get; set; }
    }

    public class StandingsList
    {
        public string Season { get; set; } 
        public string Round { get; set; }
        public List<DriverStandings> DriverStandings { get; set; }
        public List<ConstructorStandings> ConstructorStandings { get; set; }
    }

}
