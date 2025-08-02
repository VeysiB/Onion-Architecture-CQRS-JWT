using Medas.JwtAPP.Back.Core.Application.Enums;
using Medas.JwtAPP.Back.Core.Application.Features.CQRS.Commands;
using Medas.JwtAPP.Back.Core.Application.Interfaces;
using Medas.JwtAPP.Back.Core.Domain;
using MediatR;

namespace Medas.JwtAPP.Back.Core.Application.Features.CQRS.Handlers
{
    public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommandRequest>
    {
        private readonly IRepository<AppUser> _repository;
        public RegisterUserCommandHandler(IRepository<AppUser> repository)
        {
            _repository = repository;
        }
        public async Task<Unit> Handle(RegisterUserCommandRequest request, CancellationToken cancellationToken)
        {
            await _repository.CreateAsync(new AppUser
            {
                Username = request.Username,
                Password = request.Password,
                AppRoleId =(int) RoleType.Member
            });
            return Unit.Value;
        }
    }
}
