using FluentValidation;
using martianRobots.Core.Models.Base;
using martianRobots.Core.Models.ExInput;
using martianRobots.Services.MartianRobots.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace martianRobots.Controllers;

[ApiController]
[Route("[controller]")]
public class MartianRobotsController : ControllerBase
{
 
    private readonly ILogger<MartianRobotsController> _logger;
    private readonly IMartianRobotsService _martianRobotsService;
    private IValidator<CoordinatesBase> _coordinatesValidator;
    private IValidator<MartianRobotInput> _martianRobotInputValidator;

    public MartianRobotsController(
        ILogger<MartianRobotsController> logger, 
        IMartianRobotsService martianRobotsService,
        IValidator<CoordinatesBase> coordinatesValidator,
        IValidator<MartianRobotInput> martianRobotInputValidator)
    {
        _logger = logger;
        _martianRobotsService = martianRobotsService;
        _coordinatesValidator = coordinatesValidator;
        _martianRobotInputValidator = martianRobotInputValidator;
    }

    [HttpPost(Name = "PostRobots")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> PostRobots([FromBody] MartianRobotInputs inputs)
    {
        try
        {
            _logger.LogInformation("New Martians PostRobots: " + JsonSerializer.Serialize(inputs));

            if (inputs is null)
                return BadRequest("Null inputs");
            if (inputs.LandLimits is null)
                return BadRequest("Null landLimits");
            if (inputs.MartianRobots is null)
                return BadRequest("Null martianRobots");

            var validations = _coordinatesValidator.Validate(inputs.LandLimits);
            if (!validations.IsValid)
                return BadRequest("LandLimits coordinates must be less than or equal to 50.");

            foreach (var input in inputs.MartianRobots)
                if (!_martianRobotInputValidator.Validate(input).IsValid)
                    return BadRequest(
                        string.Concat(
                            "Robot coordinates must be less than or equal to 50.",
                            "Command must be less than or equal to 100."
                            )
                        );

            return Created("Created at: " + DateTime.Now, await _martianRobotsService.SendRobotsToMars(inputs));
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
        
    }
}
