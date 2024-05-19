using Application.Common.Exceptions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Product.Queries
{
    public class GetProductByIdQueryHandler : IRequestHandler<GetProductByIdQuery, ProductResult>
    {
        public GetProductByIdQueryHandler()
        {
        }

        public async Task<ProductResult> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
        {

            var product = new ProductResult(   
               Id: request.Id,
               Description: "Xiaomi 14 PRO",
               Price: 1400
               );

            return product;
        }
    }
}
