using martianRobots.Repositories.Redis.MartianData.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace martianRobots.Controllers;

[ApiController]
[Route("[controller]")]
public class MartianRobotsDataController : ControllerBase
{
 
    private readonly ILogger<MartianRobotsDataController> _logger;
    private readonly IMartianDataRepository _martianDataRepository;

    public MartianRobotsDataController(
        ILogger<MartianRobotsDataController> logger, 
        IMartianDataRepository martianDataRepository)
    {
        _logger = logger;
        _martianDataRepository = martianDataRepository;
    }

    [HttpGet("/api/MartianRobotsInputs", Name = "GetMartianRobotsInputs")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> GetMartianRobotsInputs()
    {
        try
        {
            return Ok(await _martianDataRepository.GetMartianRobotInputs());
        }
        catch (Exception ex)
        {
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
            return Ok(await _martianDataRepository.GetMartianRobotInputsWithResult());
        }
        catch (Exception ex)
        {
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
            return Ok(await _martianDataRepository.GetMarsVisitedCoordinates());
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }
}
