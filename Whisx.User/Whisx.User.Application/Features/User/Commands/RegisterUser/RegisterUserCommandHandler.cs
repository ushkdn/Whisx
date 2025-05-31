using MapsterMapper;
using MediatR;
using Whisx.Shared.Common;
using Whisx.User.Application.Common.Interfaces.Repositories;

namespace Whisx.User.Application.Features.User.Commands.RegisterUser;

public class RegisterUserCommandHandler(IMapper mapper)
    : IRequestHandler<RegisterUserCommand, HandlerResult<RegisterUserResult>>
{
    public Task<HandlerResult<RegisterUserResult>> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}