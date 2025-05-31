using Whisx.User.Domain.Entities;

namespace Whisx.User.Application.Common.Interfaces.Repositories;

public interface IUserRepository
{
    Task<UserEntity> GetUserByIdAsync(Guid userId, CancellationToken cancellationToken);

    Task<Lazy<UserEntity>> CreateUserAsync(UserEntity user, CancellationToken cancellationToken);

    Task<UserEntity> GetUserByEmailAsync(string email, CancellationToken cancellationToken);
}