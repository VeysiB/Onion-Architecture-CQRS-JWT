using AutoMapper;
using Medas.JwtAPP.Back.Core.Application.Dtos;
using Medas.JwtAPP.Back.Core.Application.Features.CQRS.Queries;
using Medas.JwtAPP.Back.Core.Application.Interfaces;
using Medas.JwtAPP.Back.Core.Domain;
using MediatR;

namespace Medas.JwtAPP.Back.Core.Application.Features.CQRS.Handlers
{
    public class GetProductQueryHandler : IRequestHandler<GetProductQueryRequest, ProductListDto>
    {
        private readonly IRepository<Product> _repository;
        private readonly IMapper _mapper;

        public GetProductQueryHandler(IRepository<Product> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ProductListDto> Handle(GetProductQueryRequest request, CancellationToken cancellationToken)
        {
            var data=await _repository.GetByFilterAsync(x=>x.Id==request.Id);
            return _mapper.Map<ProductListDto>(data);
        }
    }
}
