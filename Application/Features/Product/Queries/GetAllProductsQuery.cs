using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Product.Queries
{
    public record GetAllProductsQuery(
        int Page,
        int ItemsPerPage) : IRequest<List<ProductResult>>;
}
