using martianRobots.Services.MartianRobots.Interfaces;
using martianRobots.Services.MartianRobots;
using Moq;
using martianRobots.Repositories.Redis.MartianData.Interfaces;
using martianRobots.Core.Models.ExInput;
using martianRobots.Repositories.Redis.MartianData.Models;

namespace Core.Tests.Services.MartianRobots
{
    public class MartianDataServiceTests
    {
        private IMartianDataService _service;
        private Mock<IMartianDataRepository> _martianDataRepositoryMock;

        public MartianDataServiceTests()
        {
            _martianDataRepositoryMock = new Mock<IMartianDataRepository>();
            _service = new MartianDataService(_martianDataRepositoryMock.Object);
        }

        [Fact]
        public async Task GetMartianRobotInputs_returns_non_empty_list()
        {
            Given_an_input_list();
            var result = await When_GetMartianRobotInputs_is_invoked();
            Then_result_is_not_empty(result);
        }

        [Fact]
        public async Task GetMartianRobotInputsWithResult_returns_non_empty_list()
        {
            Given_an_input_with_result_list();
            var result = await When_GetMartianRobotInputsWithResult_is_invoked();
            Then_result_is_not_empty(result);
        }
        
        [Fact]
        public async Task GetMarsVisitedCoordinates_returns_non_empty_list()
        {
            Given_a_coordinates_list();
            var result = await When_GetMarsVisitedCoordinates_is_invoked();
            Then_result_is_not_empty(result);
        }
        
        [Fact]
        public async Task SaveMartianRobotInput_saves_input()
        {
            Given_an_input_list();
            And_Given_Ok_Response_Saving_input_list();
            var result = await When_SaveMartianRobotInput_is_invoked();
            Then_result_is(true, result);
            And_Given_GetMartianRobotInputs_Returns_inputs_within_input();
            var inputs = await When_GetMartianRobotInputs_is_invoked();
            Then_result_is_not_empty(inputs);
        }

        private void And_Given_GetMartianRobotInputs_Returns_inputs_within_input()
        {
            Given_an_input_list();
        }

        private void Then_result_is(bool desired, bool result)
        {
            Assert.Equal(desired, result);
        }

        private async Task<bool> When_SaveMartianRobotInput_is_invoked()
        {
            return await _service.SaveMartianRobotInput(new MartianRobotInput());
        }

        private void And_Given_Ok_Response_Saving_input_list()
        {
            _martianDataRepositoryMock
                .Setup(x => x.SaveMartianRobotInput(It.IsAny<MartianRobotInput>()))
                .ReturnsAsync(true);
        }

        private async Task<IEnumerable<object>> When_GetMarsVisitedCoordinates_is_invoked()
        {
            return await _service.GetMarsVisitedCoordinates();
        }

        private void Given_a_coordinates_list()
        {
            var list = new List<string>()
            {
                "NonEmpty"
            };
            _martianDataRepositoryMock
                .Setup(x => x.GetMarsVisitedCoordinates())
                .ReturnsAsync(list);
        }

        private async Task<List<MartianInputResultDto>> When_GetMartianRobotInputsWithResult_is_invoked()
        {
            return await _service.GetMartianRobotInputsWithResult();
        }

        private void Given_an_input_with_result_list()
        {
            var list = new List<MartianInputResultDto>()
            {
                new MartianInputResultDto() {}
            };
            _martianDataRepositoryMock
                .Setup(x => x.GetMartianRobotInputsWithResult())
                .ReturnsAsync(list);
        }

        private void Then_result_is_not_empty<T>(IEnumerable<T> result)
        {
            Assert.NotEmpty(result);
        }

        private async Task<List<MartianRobotInput>> When_GetMartianRobotInputs_is_invoked()
        {
            return await _service.GetMartianRobotInputs();
        }

        private void Given_an_input_list()
        {
            var list = GetInputs();
            _martianDataRepositoryMock
                .Setup(x => x.GetMartianRobotInputs())
                .ReturnsAsync(list);
        }

        private List<MartianRobotInput> GetInputs() 
        {
            return new List<MartianRobotInput>()
                   {
                        new MartianRobotInput() {}
                   };
        }
    }
}
