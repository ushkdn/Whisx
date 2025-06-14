using MediatR;
using Whisx.Shared.Common;

namespace Whisx.User.Application.Features.User.Commands.RegisterUser;

public class RegisterUserCommand : IRequest<HandlerResult<RegisterUserResult>>
{
    public required string Surname { get; set; }
    public required string Name { get; set; }
    public required string Username { get; set; }
    public required string Email { get; set; }
    public required string Password { get; set; }
    public required string ConfirmPassword { get; set; }
    public required DateOnly Birthday { get; set; }
}