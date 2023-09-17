using martianRobots.Services.MartianRobots.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace martianRobots.Controllers;

[ApiController]
[Route("[controller]")]
public class MartianRobotsDataController : ControllerBase
{
 
    private readonly ILogger<MartianRobotsDataController> _logger;
    private readonly IMartianDataService _martianDataService;

    public MartianRobotsDataController(
        ILogger<MartianRobotsDataController> logger,
        IMartianDataService martianDataService)
    {
        _logger = logger;
        _martianDataService = martianDataService;
    }

    [HttpGet("/api/MartianRobotsInputs", Name = "GetMartianRobotsInputs")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> GetMartianRobotsInputs()
    {
        try
        {
            _logger.LogInformation("GetMartianRobotsInputs");
            return Ok(await _martianDataService.GetMartianRobotInputs());
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message);
            return StatusCode(500, ex.Message);
        }
    }

    [HttpGet("/api/MartianRobotsInputsWithResult", Name = "GetMartianRobotsInputsWithResult")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> GetMartianRobotsInputsWithResult()
    {
        try
        {
            _logger.LogInformation("GetMartianRobotsInputsWithResult");
            return Ok(await _martianDataService.GetMartianRobotInputsWithResult());
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message);
            return StatusCode(500, ex.Message);
        }
    }

    [HttpGet("/api/MarsCoordinatesVisited", Name = "GetMarsCoordinatesVisited")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> GetMarsCoordinatesVisited()
    {
        try
        {
            _logger.LogInformation("GetMarsCoordinatesVisited");
            return Ok(await _martianDataService.GetMarsVisitedCoordinates());
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message);
            return StatusCode(500, ex.Message);
        }
    }
}
