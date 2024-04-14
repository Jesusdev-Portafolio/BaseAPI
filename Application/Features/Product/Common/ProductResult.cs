using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Product
{
    public record ProductResult(
        int Id,
        string Description,
        double Price);
}
