using Application.UseCases.LogIn;
using ARN.Microservices.IAM.UseCases.Authentication.Login;
using ARN.Microservices.Infrastructure;
using Microsoft.AspNetCore.Mvc;

namespace ARN.Microservices.IAM.UseCases.Authentication
{
    public class AuthenticationController : ControllerBase
    {
        private readonly ILogger<AuthenticationController> _logger;
        private readonly ILogInUseCase _loginUseCase;

        public AuthenticationController(
            ILogger<AuthenticationController> logger,
            ILogInUseCase loginUseCase)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _loginUseCase = loginUseCase ?? throw new ArgumentNullException(nameof(loginUseCase));
        }

        /// <summary>
        /// Controller: Authentication
        /// Action: Login
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        /// <response code="200">Success</response>
        /// <response code="400">
        /// Invalid payload
        /// </response>
        [Route("Login")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPost]
        [ProtectedEndpoint]
        public async Task<ActionResult<UseCaseResponse>> Login([FromBody] LogInRequest request)
        {
            _logger.LogInformation($"AuthenticationController -> Login -> START");
            var response = await _loginUseCase.Login(request.Email, request.Password);
            _logger.LogInformation($"AuthenticationController -> Login -> END");
            return Ok(response);
        }
    }
}
