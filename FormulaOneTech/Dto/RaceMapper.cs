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
        public SessionsDto FirstPractice { get; set; } = new SessionsDto();
        public SessionsDto SecondPractice { get; set; } = new SessionsDto();
        public SessionsDto ThirdPractice { get; set; } = new SessionsDto();
        public SessionsDto Qualifying { get; set; } = new SessionsDto();
        public SessionsDto? Sprint { get; set; } = new SessionsDto();
        public Circuit Circuit { get; set; }
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
            Circuit = race.Circuit,
            RaceName = race.RaceName,
            FirstPractice = new SessionsDto
            {
                SessionTime = Common.ParseSessionTime(race.FirstPractice.Date, race.FirstPractice.Time),
                Date = Common.ParseDateTime(race.FirstPractice.Date),
            },
            Qualifying = new SessionsDto
            {
                SessionTime = Common.ParseSessionTime(race.Qualifying.Date, race.Qualifying.Time),
                Date = Common.ParseDateTime(race.Qualifying.Date),
            },
            SecondPractice = new SessionsDto 
            { 
                SessionTime = Common.ParseSessionTime(race.SecondPractice.Date, race.SecondPractice.Time),
                Date = Common.ParseDateTime(race.SecondPractice.Date),
            },
            ThirdPractice = new SessionsDto 
            { 
                SessionTime = Common.ParseSessionTime(race.ThirdPractice.Date, race.ThirdPractice.Time),
                Date = Common.ParseDateTime(race.ThirdPractice.Date),
            },
            Sprint = race.Sprint != null ? new SessionsDto 
            { 
                SessionTime = Common.ParseSessionTime(race.Sprint.Date, race.Sprint.Time),
                Date = Common.ParseDateTime(race.Sprint.Date),
            } : null,
        };
    }
}

