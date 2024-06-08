namespace FormulaOneTech.Models.Ergast
{
    public class Result
    {
        public string Number { get; set; }
        public string Position { get; set; }
        public string PositionText { get; set; }
        public string Points { get; set; }
        public Driver Driver { get; set; }
        public Constructor Constructor { get; set; }
        public string Grid { get; set; }
        public string Laps { get; set; }
        public string Status { get; set; }
        public Time? Time { get; set; }
    }

    public class Time
    {
        public string Millis { get; set; }
        public string time { get; set; }
    }
}
