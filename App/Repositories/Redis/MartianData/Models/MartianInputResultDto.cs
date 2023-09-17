using martianRobots.Core.Models.ExInput;

namespace martianRobots.Repositories.Redis.MartianData.Models
{
    public class MartianInputResultDto
    {
        public string Result { get; set; } = string.Empty;
        public MartianRobotInput Input { get; set; } = new MartianRobotInput();


        public MartianInputResultDto() { }

        public MartianInputResultDto(MartianRobotInput input, string result) 
        {
            Result = result;
            Input = input;
        }
    }
}
