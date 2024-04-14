using Application.Common.Interfaces;
using Domain.IRepositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Product.Commands
{
    public class CreateProductCommanHandler : IRequestHandler<CreateProductCommand, ProductResult>
    {
        private readonly IUoW _uoW;
        public CreateProductCommanHandler( IUoW uoW)
        {
            _uoW = uoW;
        }

        public async Task<ProductResult> Handle(CreateProductCommand command, CancellationToken cancellationToken)
        {
            Random rnd = new();
            Domain.Entities.Product product = new() { Id = rnd.Next(), Description = command.Description, Price = command.Price };
            int result =  await _uoW.Product.SaveProduct(product);

            return new ProductResult(
                       Id: product.Id,
                       Description: product.Description,
                       Price: product.Price
                );
        }
    }
}
