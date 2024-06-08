using Microsoft.AspNetCore.Components.Routing;
using Microsoft.AspNetCore.Components.Server.Circuits;

namespace FormulaOneTech.Models.Ergast
{
    public class Race
    {
        public string Season { get; set; }
        public string Round { get; set; }
        public string RaceName { get; set; }
        public Circuit Circuit { get; set; }
        public string Date { get; set; }
        public string Time { get; set; }
        public FirstPractice FirstPractice { get; set; }
        public SecondPractice SecondPractice { get; set; }
        public ThirdPractice ThirdPractice { get; set; }
        public Qualifying Qualifying { get; set; }
        public List<QualifyingResults> QualifyingResults { get; set; }
        public Sprint Sprint { get; set; }
        public List<Result> Results { get; set; }
    }

    public class Circuit
    {
        public string CircuitId { get; set; }
        public string CircuitName { get; set; }

        public Location Location { get; set; }
    }
    public class Location
    {
        public string Lat { get; set; }
        public string Long { get; set; }
        public string Locality { get; set; }
        public string Country { get; set; }
    }

    public class FirstPractice
    {
        public string Date { get; set; }
        public string Time { get; set; }
    }
   
    public class ThirdPractice
    {
        public string Date { get; set; }
        public string Time { get; set; }
    }

    public class SecondPractice
    {
        public string Date { get; set; }
        public string Time { get; set; }
    }
    public class Sprint
    {
        public string Date { get; set; }
        public string Time { get; set; }
    }
    public class Qualifying
    {
        public string Date { get; set; }
        public string Time { get; set; }
    }

    public class QualifyingResults
    {
        public string? Number { get; set; }
        public string? Position { get; set; }
        public Driver Driver { get; set; }
        public Constructor Constructor { get; set; }
        public string? Q1 { get; set; }
        public string? Q2 { get; set; }
        public string? Q3 { get; set; }
    }
}
