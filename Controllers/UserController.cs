using Microsoft.AspNetCore.Mvc;
using UseCaseInterfaces;
using ViewModels;

namespace api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
    private readonly IUserUseCase _userUseCase;
    private readonly ILogger<UserController> _logger;

    public UserController(IUserUseCase userUseCase, ILogger<UserController> logger)
    {
        _userUseCase = userUseCase;
        _logger = logger;
    }

    [HttpPost("create")]
    public IActionResult CreateAccount([FromBody] UserDto request)
    {
        if (request == null || string.IsNullOrEmpty(request.Name) || string.IsNullOrEmpty(request.Email) || string.IsNullOrEmpty(request.Password))
        {
            _logger.LogWarning("Invalid request received");
            return BadRequest("Invalid request data");
        }
        try
        {
            var result = _userUseCase.execute(request);
            return Ok(new { Success = true, Data = result });
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error while processing the request");
            return StatusCode(500, "An error occurred while processing your request.");
        }
    }
    [HttpGet("usage-list")]
    public IActionResult UsageList()
    {
        // if (request == null || request.remoteId == 0 || string.IsNullOrEmpty(request.remoteName) || string.IsNullOrEmpty(request.usedBy) || string.IsNullOrEmpty(request.role))
        // {
        //     _logger.LogWarning("Invalid request received");
        //     return BadRequest("Invalid request data");
        // }
        try
        {
            var result = _userUseCase.usageList();
            return Ok(new { Success = true, Data = result });
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error while processing the request");
            return StatusCode(500, "An error occurred while processing your request.");
        }
    }
    [HttpGet("user-list")]
    public IActionResult UserList()
    {
        try
        {
            var result = _userUseCase.userList();
            return Ok(new { Success = true, Data = result });
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error while processing the request");
            return StatusCode(500, "An error occurred while processing your request.");
        }
    }
    // [HttpPut("{remoteId}")]
    // public IActionResult UpdateUsedBy(string remoteId, [FromBody] UpdateUsedByRequest request)
    // {
    //     var systemUsage = _dbContext.SystemUsageList.FirstOrDefault(s => s.RemoteId == remoteId);
    //     if (systemUsage == null)
    //     {
    //         return NotFound();
    //     }

    //     systemUsage.UsedBy = request.UsedBy;
    //     _dbContext.SaveChanges();

    //     return Ok(new { message = "Update successful" });
    // }
    [HttpPut("user-by")]
    public IActionResult UpdateUsedBy([FromBody] UserByDto request)
    {
        if (request == null || string.IsNullOrEmpty(request.RemoteId) || string.IsNullOrEmpty(request.User))
        {
            _logger.LogWarning("Invalid request received");
            return BadRequest("Invalid request data");
        }
        try
        {
            var result = _userUseCase.userBy(request);

            return Ok(new { Success = true, Data = result });
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error while processing the request");
            return StatusCode(500, "An error occurred while processing your request.");
        }
    }
}
