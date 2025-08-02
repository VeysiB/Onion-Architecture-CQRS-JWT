using Medas.JwtAPP.Back.Core.Application.Features.CQRS.Commands;
using Medas.JwtAPP.Back.Core.Application.Interfaces;
using Medas.JwtAPP.Back.Core.Domain;
using MediatR;

namespace Medas.JwtAPP.Back.Core.Application.Features.CQRS.Handlers
{
    public class DeleteCategoryCommandHandler : IRequestHandler<DeleteCategoryCommandRequest>
    {
        private readonly IRepository<Category> _repository;
        public DeleteCategoryCommandHandler(IRepository<Category> repository)
        {
            _repository = repository;
        }
        public async Task<Unit> Handle(DeleteCategoryCommandRequest request, CancellationToken cancellationToken)
        {
            var deletedEntity=await _repository.GetByIdAsync(request.Id);
            if(deletedEntity != null)
            {
                await _repository.RemoveAsync(deletedEntity);
            }
            return Unit.Value;
        }
    }
}
