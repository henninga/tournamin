namespace Tournamin.web.Models
{
    public class GroupMatch
    {
        public string TeamA { get; set; }
        public string TeamB { get; set; }
        public uint ScoreA { get; set; }
        public uint ScoreB { get; set; }

        public GroupMatch(string teamA, string teamB)
        {
            TeamA = teamA;
            TeamB = teamB;
        }
    }
}