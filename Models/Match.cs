using Newtonsoft.Json;

namespace FootballMatches.Models
{
    public class ApiResponse
    {
        [JsonProperty("matches")]
        public List<Match> Matches { get; set; }
    }

    public class Match
    {

        [JsonProperty("competition")]
        public Competition Competition { get; set; }

        [JsonProperty("utcDate")]
        public DateTime UtcDate { get; set; }

        [JsonProperty("homeTeam")]
        public Team HomeTeam { get; set; }

        [JsonProperty("awayTeam")]
        public Team AwayTeam { get; set; }
    }

    public class Competition
    {
        [JsonProperty("name")]
        public string Name { get; set; }
    }

    public class Team
    {
        [JsonProperty("name")]
        public string Name { get; set; }
    }
}
