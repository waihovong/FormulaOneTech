namespace FormulaOneTech.Models.Ergast
{
    public class DriverStandings
    {
        public string Position { get; set; }
        public string Points { get; set; }
        public string Wins { get; set; }
        public Driver Driver { get; set; }
        public List<Constructor> Constructors { get; set; }
    }
}
