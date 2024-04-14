using Application.Common.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Product.Commands
{
    public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand, int>
    {
        private readonly IUoW _uoW;

        public DeleteProductCommandHandler(IUoW uoW)
        {
            _uoW = uoW;
        }

        public async Task<int> Handle(DeleteProductCommand command, CancellationToken cancellationToken)
        {

            Domain.Entities.Product product = await _uoW.Product.GetProductById(command.Id);

            //if (product is null) throw new NotFoundProductException();

            int result = await _uoW.Product.DeleteProduct(product.Id);

            return result;


        }
    }
}
