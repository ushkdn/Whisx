using Mapster;
using Whisx.User.Domain.Entities;

namespace Whisx.User.Application.Features.User.Commands.RegisterUser;

public static class RegisterUserMapping
{
    public static void Configure()
    {
        TypeAdapterConfig<RegisterUserCommand, UserEntity>.NewConfig();
        TypeAdapterConfig<UserEntity, RegisterUserResult>.NewConfig();
    }
}