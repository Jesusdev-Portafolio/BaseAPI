using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Product.Commands
{
    public record CreateProductCommand(
        string Description,
        double Price) : IRequest<ProductResult>;

  
}
