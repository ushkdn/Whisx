using Whisx.Shared.Base.Entities;

namespace Whisx.User.Domain.Entities;

public class UserEntity : EntityBase
{
    public string Surname { get; set; }

    public string Name { get; set; }

    public string Username { get; set; }

    public string Email { get; set; }

    public string Password { get; set; }

    public DateOnly Birthday { get; set; }

    public bool IsVerified { get; set; } = false;
}