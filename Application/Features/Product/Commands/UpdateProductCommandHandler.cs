using Application.Common.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Product.Commands
{
    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, ProductResult>
    {
        IUoW _uoW;
        public UpdateProductCommandHandler( IUoW uoW)
        {
            _uoW = uoW;
        }

        public async  Task<ProductResult> Handle(UpdateProductCommand command, CancellationToken cancellationToken)
        {
            Domain.Entities.Product product = new() { Id = command.Id, Description = command.Description, Price = command.Price };
            int result = await _uoW.Product.SaveProduct(product);

            return new ProductResult(
                       Id: product.Id,
                       Description: product.Description,
                       Price: product.Price
                );
        }
    }
}
