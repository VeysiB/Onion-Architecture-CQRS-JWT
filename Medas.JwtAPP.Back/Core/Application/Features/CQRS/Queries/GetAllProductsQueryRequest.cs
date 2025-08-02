using Medas.JwtAPP.Back.Core.Application.Dtos;
using MediatR;

namespace Medas.JwtAPP.Back.Core.Application.Features.CQRS.Queries
{
    public class GetAllProductsQueryRequest:IRequest<List<ProductListDto>>
    {
    }
}
