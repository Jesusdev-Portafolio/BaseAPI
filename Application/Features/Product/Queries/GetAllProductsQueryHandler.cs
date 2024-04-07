using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Product.Queries
{
    public class GetAllProductsQueryHandler : IRequestHandler<GetAllProductsQuery, List<ProductResult>>
    {
        public GetAllProductsQueryHandler()
        {
        }

        public async Task<List<ProductResult>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
        {

            var product = new ProductResult(
                Description : "Samsungs24",
                Price : 1300
                );


            var prouct2 = new ProductResult(
                Description : "Iphone 15 pro max",
                Price : 1500)
                ;

            var productList = new List<ProductResult>() { product, prouct2};

            return productList;
            
        }
    }
}
