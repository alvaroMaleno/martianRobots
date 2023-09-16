using martianRobots.Core.Models.Base;

namespace martianRobots.Repositories.Redis.MartianLosts.Models
{
    public class MartianLosts
    {
        public string Orientation {  get; set; }
        public CoordinatesBase LandMaxCoordinates { get; set; } = new CoordinatesBase();
        public Dictionary<string, List<CoordinatesBase>> Scents { get; set; }

        public MartianLosts(
            string orientation,
            CoordinatesBase landMaxCoordinates, 
            Dictionary<string, List<CoordinatesBase>> scents
            ) 
        {
            Orientation = orientation;
            LandMaxCoordinates = landMaxCoordinates;
            Scents = scents;
        }

        public string GetKey() 
        {
            return 
                string.Concat(
                    LandMaxCoordinates.x, 
                    LandMaxCoordinates.y, 
                    Orientation
                    );
        }
    }
}
