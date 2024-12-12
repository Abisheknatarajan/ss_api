using Microsoft.AspNetCore.Mvc;
using UseCaseInterfaces;
using ViewModels;
namespace api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class RemoteRegController : ControllerBase
{

    private readonly IRemoteRegisterUseCase _RemoteRegisterUseCase;

    private readonly ILogger<RemoteRegController> _logger;

    public RemoteRegController(IRemoteRegisterUseCase RemoteRegisterUseCase
    , ILogger<RemoteRegController> logger)
    {
        _RemoteRegisterUseCase = RemoteRegisterUseCase;
        _logger = logger;
    }

    [HttpPost("RemoteReg")]
    public ActionResult executeRemoteReg(RemoteRegisterDto request)
    {
        if (request == null || string.IsNullOrEmpty(request.remoteID) || string.IsNullOrEmpty(request.remoteUserName))
        {
            _logger.LogWarning("Invalid request received");
            return BadRequest("Invalid request data");
        }
        try
        {
            // リモートデスクトップIDと名前を登録
            _logger.LogError("RemoteRegister");

            var result = _RemoteRegisterUseCase.executeRegister(request);
            if(result != ""){
                return Ok(new { Success = true, Data = result });
            }
            else {
                return Ok(new { Success = false, Data = result });
            }

        }
        catch (Exception ex)
        {
            _logger.LogError(ex.ToString());
            return StatusCode(500, "An error occurred while processing your request."); ;
        }
    }

}
