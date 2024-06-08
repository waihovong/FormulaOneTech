using FormulaOneTech.Models.Ergast;
using FormulaOneTech.Helpers;

public static class RaceMapper
{
    public class RaceDto
    {
        public string Season { get; set; }
        public string Round { get; set; }
        public DateTime? Date { get; set; }
        public string Time { get; set; }
        public string RaceName { get; set; }
        public DateTime? SessionTime { get; set; }
        public SessionsDto? FirstPractice { get; set; } = new SessionsDto();
        public SessionsDto? SecondPractice { get; set; } = new SessionsDto();
        public SessionsDto? ThirdPractice { get; set; } = new SessionsDto();
        public SessionsDto? Qualifying { get; set; } = new SessionsDto();
        public SessionsDto? Sprint { get; set; } = new SessionsDto();
        public Circuit Circuit { get; set; }
        public List<Result> Results { get; set; }
        public List<QualifyingResults> QualifyingResults { get; set; }
    }

    public class SessionsDto
    {
        public DateTime? Date { get; set; }
        public DateTime? Time { get; set; }
        public DateTime? SessionTime { get; set; }
    }

    public static RaceDto RaceMapDto(Race race)
    {
        return new RaceDto
        {
            Date = Common.ParseDateTime(race.Date),
            SessionTime = Common.ParseSessionTime(race.Date, race.Time),
            Round = race.Round,
            Season = race.Season,
            Time = race.Time,
            QualifyingResults = race.QualifyingResults,
            Circuit = race.Circuit,
            RaceName = race.RaceName,
            Results = race.Results,
            FirstPractice = race.FirstPractice != null ? new SessionsDto
            {
                SessionTime = Common.ParseSessionTime(race.FirstPractice.Date, race.FirstPractice.Time),
                Date = Common.ParseDateTime(race.FirstPractice.Date),
            } : null,
            Qualifying = race.Qualifying != null ? new SessionsDto
            {
                SessionTime = Common.ParseSessionTime(race.Qualifying.Date, race.Qualifying.Time),
                Date = Common.ParseDateTime(race.Qualifying.Date),
            } : null,
            SecondPractice = race.SecondPractice != null ? new SessionsDto 
            { 
                SessionTime = Common.ParseSessionTime(race.SecondPractice.Date, race.SecondPractice.Time),
                Date = Common.ParseDateTime(race.SecondPractice.Date),
            } : null,
            ThirdPractice = race.ThirdPractice != null ? new SessionsDto 
            { 
                SessionTime = Common.ParseSessionTime(race.ThirdPractice.Date, race.ThirdPractice.Time),
                Date = Common.ParseDateTime(race.ThirdPractice.Date),
            } : null,
            Sprint = race.Sprint != null ? new SessionsDto 
            { 
                SessionTime = Common.ParseSessionTime(race.Sprint.Date, race.Sprint.Time),
                Date = Common.ParseDateTime(race.Sprint.Date),
            } : null,
        };
    }
}

