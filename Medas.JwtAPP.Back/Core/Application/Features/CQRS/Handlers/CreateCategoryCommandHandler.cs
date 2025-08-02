﻿using Medas.JwtAPP.Back.Core.Application.Features.CQRS.Commands;
using Medas.JwtAPP.Back.Core.Application.Interfaces;
using Medas.JwtAPP.Back.Core.Domain;
using MediatR;

namespace Medas.JwtAPP.Back.Core.Application.Features.CQRS.Handlers
{
    public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommandRequest>
    {
        private readonly IRepository<Category> _repository;

        public CreateCategoryCommandHandler(IRepository<Category> repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(CreateCategoryCommandRequest request, CancellationToken cancellationToken)
        {
          await  _repository.CreateAsync(new Category
            {
                Definition = request.Definition
            });
            return Unit.Value;
        }
    }
}
