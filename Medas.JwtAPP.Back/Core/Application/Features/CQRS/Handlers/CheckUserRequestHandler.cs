using Medas.JwtAPP.Back.Core.Application.Dtos;
using Medas.JwtAPP.Back.Core.Application.Features.CQRS.Queries;
using Medas.JwtAPP.Back.Core.Application.Interfaces;
using Medas.JwtAPP.Back.Core.Domain;
using MediatR;

namespace Medas.JwtAPP.Back.Core.Application.Features.CQRS.Handlers
{
    public class CheckUserRequestHandler : IRequestHandler<CheckUserQueryRequest, CheckUserResponseDto>
    {
        private readonly IRepository<AppUser> _userRepository;
        private readonly IRepository<AppRole> _roleRepository;

        public CheckUserRequestHandler(IRepository<AppUser> userRepository, IRepository<AppRole> roleRepository)
        {
            _userRepository = userRepository;
            _roleRepository = roleRepository;
        }

        public async Task<CheckUserResponseDto> Handle(CheckUserQueryRequest request, CancellationToken cancellationToken)
        {
            var dto=new CheckUserResponseDto();
            var user=await _userRepository.GetByFilterAsync(x=>x.Username==request.Username && x.Password==request.Password);
            if (user == null)
            {
                dto.IsExist = false;
            }
            else
            {
                dto.Username= request.Username;
                dto.Id = user.Id;
                dto.IsExist = true;
                var role = await _roleRepository.GetByFilterAsync(x => x.Id == user.AppRoleId);
                dto.Role = role?.Definition;
            }
            return dto;
        }
    }
}
