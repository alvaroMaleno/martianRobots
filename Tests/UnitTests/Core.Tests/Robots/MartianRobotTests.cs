﻿using martianRobots.Core.Models;
using martianRobots.Core.Models.ExInput;
using martianRobots.Core.Models.Land;
using martianRobots.Core.Movement;
using martianRobots.Core.Robots;
using martianRobots.Repositories.Redis.MartianLosts.Interfaces;
using Moq;


namespace Core.Tests.Robots
{
    public class MartianRobotTests
    {
        private Mock<IMartianRobotLostRepository> _repositoryMock;
        private MartianRobot _robotToTest;

        public MartianRobotTests() 
        {
            _repositoryMock = new Mock<IMartianRobotLostRepository>();
            _robotToTest = new MartianRobot(new TwoDCoordinates(), new TwoDMovement(), new MarsLand(_repositoryMock.Object));
        }

        [Theory]
        [InlineData(1, 1, "RFRFRFRF", "E", "1 1 E")]
        [InlineData(3, 2, "FRRFLLFFRRFLL", "N", "3 3 N LOST")]
        [InlineData(0, 3, "LLFFFRFLFL", "W", "4 2 N")]
        public void ExecuteMovementCommands_runs_on_returning_well_results(
            int x, 
            int y, 
            string command, 
            string orientation, 
            string result)
        {
           
            var input = Given_a_martian_robot_input(x, y, command, orientation);
            When_martian_robot_execute_movement(input);
            Then_martian_output_is_equals_to(result);
           
        }

        private void Then_martian_output_is_equals_to(string result)
        {
            Assert.Equal(_robotToTest.ToString(), result);
        }

        private void When_martian_robot_execute_movement(MartianRobotInput input)
        {
            _robotToTest.Start(input, new TwoDCoordinates(5, 3));
            _robotToTest.ExecuteMovementCommands();
        }

        private MartianRobotInput Given_a_martian_robot_input(int x, int y, string command, string orientation)
        {
            return 
                new MartianRobotInput()
                {
                        RobotCoordinates = new TwoDCoordinates(x, y),
                        Command = command,
                        Orientation = orientation
                };
                   
        }       
        
    }
}
