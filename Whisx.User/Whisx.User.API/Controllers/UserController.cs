using MediatR;
using Microsoft.AspNetCore.Mvc;
using Whisx.Shared.Common;
using Whisx.User.Application.Features.User.Commands.RegisterUser;

namespace Whisx.User.API.Controllers;

[Route("api/users")]
[ApiController]
public class UserController(ILogger<UserController> logger, IMediator mediator) : ControllerBase
{
    [HttpPost("register")]
    public async Task<ActionResult<HandlerResult<RegisterUserResult>>> Register(
        [FromBody] RegisterUserCommand registerUserCommand,
        CancellationToken cancellationToken)
    {
        logger.LogInformation("Incoming request: {@request}", registerUserCommand);

        cancellationToken.ThrowIfCancellationRequested();

        var result = await mediator.Send(registerUserCommand, cancellationToken);

        if (!result.Success)
        {
            return BadRequest(result);
        }

        return Ok(result);
    }
}