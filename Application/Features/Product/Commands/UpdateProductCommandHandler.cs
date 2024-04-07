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
        public UpdateProductCommandHandler()
        {
        }

        public async  Task<ProductResult> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            ProductResult result = new ProductResult(
                Description: request.Description + " Actualizado",
                Price: request.Price
                );

            return result;


        }
    }
}
