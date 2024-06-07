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
    }

    public class Constructor
    {
        public string ConstructorId { get; set; }
        public string Url { get; set; }
        public string Name { get; set; }
        public string Nationality { get; set; }
    }

}
