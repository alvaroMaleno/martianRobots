namespace martianRobots.Services.MartianRobots.Models
{
    public class MartianDataStatsResult
    {
        public int TotalOks { get; set; }
        public int TotalLosts { get; set; }
        public int TotalEnvies { get; set; }
        public double OksPercentage { get; set; }
        public double LostsPercentage { get; set; }
        public int TotalCoordinates { get; set; }
    }
}
