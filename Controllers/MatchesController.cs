using FootballMatches.Common;
using FootballMatches.Models;
using FootballMatches.Services;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace FootballMatches.Controllers
{
    public class MatchesController : Controller
    {
        private readonly FootballDataService _footballDataService;

        public MatchesController(FootballDataService footballDataService)
        {
            _footballDataService = footballDataService;
        }

        /// <summary>
        /// Return the general view
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return View();
        }

        /// <summary>
        /// Return the matches based on the type
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetMatches(string type)
        {

            if (!Enum.TryParse(type, true, out MatchTypes typem))
            {
                typem = MatchTypes.SCHEDULED;
            }

            try
            {
                var response = await _footballDataService.GetMatchesAsync(typem);

                var results = JsonConvert.DeserializeObject<ApiResponse>(response);
                List<LeagueMatchesViewModel> matches;

                if (results?.Matches.Count > 0)
                {
                    matches = GroupingMatchesForView(results.Matches);
                }
                else
                {
                    //HACK: Mock data if API return empty result, and the app is showing how is carusel working
                    matches = GroupingMatchesForView(GetMockData());
                }

                ViewData["MatchType"] = type;
                return View("Index", matches);
            }
            catch
            {
                //TODO: Log the exception
                //HACK: Mock data if API is not available, and the app is showing how is carusel working
                ViewData["MatchType"] = type;
                return View("Index", GroupingMatchesForView(GetMockData()));
            }
        }

        /// <summary>
        /// Method to group the matches by competition
        /// </summary>
        /// <param name="results"></param>
        /// <returns></returns>
        private static List<LeagueMatchesViewModel>? GroupingMatchesForView(List<Match> results)
        {
            return results?
                .OrderBy(m => m.Competition.Name)
                .GroupBy(m => m.Competition.Name)
                .Select(g => new LeagueMatchesViewModel { CompetitionName = g.Key, Matches = g.ToList() }).ToList();
        }

        /// <summary>
        /// Create a mock data to show the carousel
        /// </summary>
        /// <returns></returns>
        private List<Match> GetMockData()
        {
            return new List<Match>
            {
             // Primeira Liga (Portugal)
              new Match
              {
            Competition = new Competition { Name = "Primeira Liga (Portugal)" },
            HomeTeam = new Team { Name = "FC Porto" },
            AwayTeam = new Team { Name = "Benfica" },
            UtcDate = DateTime.UtcNow.AddDays(1)
        },
        new Match
        {
            Competition = new Competition { Name = "Primeira Liga (Portugal)" },
            HomeTeam = new Team { Name = "Sporting Lisbon" },
            AwayTeam = new Team { Name = "Braga" },
            UtcDate = DateTime.UtcNow.AddDays(2)
        },

        // Premier League (England)
        new Match
        {
            Competition = new Competition { Name = "Premier League (England)" },
            HomeTeam = new Team { Name = "Manchester United" },
            AwayTeam = new Team { Name = "Liverpool" },
            UtcDate = DateTime.UtcNow.AddDays(2)
        },
        new Match
        {
            Competition = new Competition { Name = "Premier League (England)" },
            HomeTeam = new Team { Name = "Chelsea" },
            AwayTeam = new Team { Name = "Arsenal" },
            UtcDate = DateTime.UtcNow.AddDays(3)
        },

        // Eredivisie (Netherlands)
        new Match
        {
            Competition = new Competition { Name = "Eredivisie (Netherlands)" },
            HomeTeam = new Team { Name = "Ajax" },
            AwayTeam = new Team { Name = "PSV Eindhoven" },
            UtcDate = DateTime.UtcNow.AddDays(3)
        },
        new Match
        {
            Competition = new Competition { Name = "Eredivisie (Netherlands)" },
            HomeTeam = new Team { Name = "Feyenoord" },
            AwayTeam = new Team { Name = "Utrecht" },
            UtcDate = DateTime.UtcNow.AddDays(4)
        },

        // Bundesliga (Germany)
        new Match
        {
            Competition = new Competition { Name = "Bundesliga (Germany)" },
            HomeTeam = new Team { Name = "Bayern Munich" },
            AwayTeam = new Team { Name = "Borussia Dortmund" },
            UtcDate = DateTime.UtcNow.AddDays(4)
        },
        new Match
        {
            Competition = new Competition { Name = "Bundesliga (Germany)" },
            HomeTeam = new Team { Name = "RB Leipzig" },
            AwayTeam = new Team { Name = "Bayer Leverkusen" },
            UtcDate = DateTime.UtcNow.AddDays(5)
        },

        // Serie A (Italy)
        new Match
        {
            Competition = new Competition { Name = "Serie A (Italy)" },
            HomeTeam = new Team { Name = "Juventus" },
            AwayTeam = new Team { Name = "AC Milan" },
            UtcDate = DateTime.UtcNow.AddDays(5)
        },
        new Match
        {
            Competition = new Competition { Name = "Serie A (Italy)" },
            HomeTeam = new Team { Name = "Inter Milan" },
            AwayTeam = new Team { Name = "Napoli" },
            UtcDate = DateTime.UtcNow.AddDays(6)
        },

        // La Liga (Spain)
        new Match
        {
            Competition = new Competition { Name = "La Liga (Spain)" },
            HomeTeam = new Team { Name = "Barcelona" },
            AwayTeam = new Team { Name = "Real Madrid" },
            UtcDate = DateTime.UtcNow.AddDays(6)
        },
        new Match
        {
            Competition = new Competition { Name = "La Liga (Spain)" },
            HomeTeam = new Team { Name = "Atletico Madrid" },
            AwayTeam = new Team { Name = "Sevilla" },
            UtcDate = DateTime.UtcNow.AddDays(7)
        },

        // Serie A (Brazil)
        new Match
        {
            Competition = new Competition { Name = "Serie A (Brazil)" },
            HomeTeam = new Team { Name = "Flamengo" },
            AwayTeam = new Team { Name = "Palmeiras" },
            UtcDate = DateTime.UtcNow.AddDays(7)
        },
             new Match
             {
            Competition = new Competition { Name = "Serie A (Brazil)" },
            HomeTeam = new Team { Name = "Sao Paulo" },
            AwayTeam = new Team { Name = "Corinthians" },
            UtcDate = DateTime.UtcNow.AddDays(8)
        }
        };
        }
    }
}
