using Whisx.Shared.Base.Entities;

namespace Whisx.User.Domain.Entities;

public class UserEntity : EntityBase
{
    public required string Surname { get; set; }

    public required string Name { get; set; }

    public required string Username { get; set; }

    public required string Email { get; set; }

    public required string Password { get; set; }

    public required DateOnly Birthday { get; set; }

    public bool IsVerified { get; set; } = false;
}