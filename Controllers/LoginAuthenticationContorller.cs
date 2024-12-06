using Microsoft.AspNetCore.Mvc;
using UseCaseInterfaces;
using ViewModels;
namespace api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class LoginController : ControllerBase
{

    private readonly ILoginAuthenticationUseCase LoginAuthenticationUseCase;

    private readonly ILogger<LoginController> _logger;

    public LoginController(ILoginAuthenticationUseCase loginAuthenticationUseCase
    , ILogger<LoginController> logger)
    {
        LoginAuthenticationUseCase = loginAuthenticationUseCase;
        _logger = logger;
    }

    [HttpPost("login")]
    public ActionResult authenticate(LoginAuthenticationDto request)
    {
        if (request == null || string.IsNullOrEmpty(request.email) || string.IsNullOrEmpty(request.password))
        {
            _logger.LogWarning("Invalid request received");
            return BadRequest("Invalid request data");
        }
        try
        {
            // TODO 検証用のログ、後で削除する
            _logger.LogError("loginauthentication");

            var result = LoginAuthenticationUseCase.executeAuthentication(request);
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
