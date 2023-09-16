using martianRobots.Core.Models;
using martianRobots.Core.Models.ExInput;
using martianRobots.Core.Models.Land;
using martianRobots.Services.MartianRobots;
using martianRobots.Services.MartianRobots.Interfaces;
using martianRobots.Services.MartianRobots.Models;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace martianRobots.Controllers;

[ApiController]
[Route("[controller]")]
public class MartianRobotsController : ControllerBase
{
 
    private readonly ILogger<MartianRobotsController> _logger;
    private readonly IMartianRobotsService _martianRobotsService;

    public MartianRobotsController(ILogger<MartianRobotsController> logger, IMartianRobotsService martianRobotsService)
    {
        _logger = logger;
        _martianRobotsService = martianRobotsService;
    }

    [HttpPost(Name = "PostRobots")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> PostRobots([FromBody] MartianRobotInputs inputs)
    {
        _logger.LogInformation("New Martians PostRobots: " + JsonSerializer.Serialize(inputs));
        return Created("Created at: " + DateTime.Now, _martianRobotsService.SendRobotsToMars(inputs));
    }
}
