using Medas.JwtAPP.Back.Core.Application.Dtos;
using MediatR;

namespace Medas.JwtAPP.Back.Core.Application.Features.CQRS.Queries
{
    public class GetCategoryQueryRequest:IRequest<CategoryListDto?>
    {
        public int Id { get; set; }
        public GetCategoryQueryRequest(int id)
        {
            Id= id;
        }
    }
}
