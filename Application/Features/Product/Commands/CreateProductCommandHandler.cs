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
        public CreateProductCommanHandler()
        {
        }

        public async Task<ProductResult> Handle(CreateProductCommand command, CancellationToken cancellationToken)
        {
      
            ProductResult result = new ProductResult(
                command.Description,
                command.Price
                );

            return result;
        }
    }
}
