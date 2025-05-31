using MediatR;
using Whisx.Shared.Common;

namespace Whisx.User.Application.Features.User.Commands.RegisterUser;

public class RegisterUserCommand : IRequest<HandlerResult<RegisterUserResult>>
{
    public string Surname { get; set; }
    public string Name { get; set; }
    public string Username { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string ConfirmPassword { get; set; }
    public DateOnly Birthday { get; set; }
}