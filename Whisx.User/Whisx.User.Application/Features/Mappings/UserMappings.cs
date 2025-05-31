using Whisx.User.Application.Features.User.Commands.RegisterUser;

namespace Whisx.User.Application.Features.Mappings;

public static class UserMappings
{
    public static void Configure()
    {
        RegisterUserMapping.Configure();
    }
}