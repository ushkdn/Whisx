using MapsterMapper;
using MediatR;
using Whisx.Shared.Common;

namespace Whisx.User.Application.Features.User.Commands.RegisterUser;

public class RegisterUserCommandHandler(IMapper mapper)
    : IRequestHandler<RegisterUserCommand, HandlerResult<RegisterUserResult>>
{
    public async Task<HandlerResult<RegisterUserResult>> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
    {
        return new HandlerResult<RegisterUserResult>();
    }
}