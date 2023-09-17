using martianRobots.Core.Models;
using martianRobots.Core.Models.ExInput;
using martianRobots.Core.Robots.Interfaces;
using martianRobots.Services.MartianRobots;
using martianRobots.Services.MartianRobots.Interfaces;
using martianRobots.Services.MartianRobots.Models;
using Moq;

namespace Core.Tests.Services.MartianRobots
{
    public class MartianRobotsServiceTests
    {
        private MartianRobotsResult _result;
        private IMartianRobotsService _service;
        private Mock<IRobot> _robotMock;
        private Mock<IMartianDataService> _martianDataService;

        public MartianRobotsServiceTests() 
        {
            _robotMock = new Mock<IRobot>();
            _martianDataService = new Mock<IMartianDataService>();
            _service = new MartianRobotsService(_robotMock.Object, _martianDataService.Object);
        }

        [Fact]
        public async Task SendRobotsToMars_returns_non_empty_result()
        {

            var input = Given_an_input();
            Given_an_output();
            await When_Robots_Are_Sent_to_Mars(input);
            Then_Result_Contains_Outputs();
            And_Also_Ouput_Is_Equal_to("output");
        }

        private void And_Also_Ouput_Is_Equal_to(string v)
        {
            Assert.Equal("output", _result.MartianRobotsResults.First());
        }

        private void Then_Result_Contains_Outputs()
        {
            Assert.NotEmpty(_result.MartianRobotsResults);
        }

        private async Task When_Robots_Are_Sent_to_Mars(MartianRobotInputs input)
        {
            _result = await _service.SendRobotsToMars(input);
        }

        private void Given_an_output()
        {
            _robotMock.Setup(x => x.ToString()).Returns("output");
        }

        private MartianRobotInputs Given_an_input()
        {
            var input = new MartianRobotInputs();
            input.LandLimits = new TwoDCoordinates(1, 3);
            input.MartianRobots.Add(
                new MartianRobotInput() 
                {
                    RobotCoordinates = new TwoDCoordinates(1, 3),
                    Command = "FWSFFFF",
                    Orientation = "N"
                }
                );
            return input;
        }
    }
}
