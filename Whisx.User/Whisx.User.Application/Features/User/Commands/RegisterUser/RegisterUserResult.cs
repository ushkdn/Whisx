namespace Whisx.User.Application.Features.User.Commands.RegisterUser;

public record RegisterUserResult(
    Guid UserId,
    string Username,
    string Surname,
    string Name,
    string Email,
    DateOnly Birthday,
    DateTime DateCreated);