using Application.Common.Interfaces;
using Domain.IRepositories;
using Infrastructure.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence
{
    public class UoW : IUoW
    {
        //TODO declaramos el context
        public UoW()
        {
            //TODO lo inyectamos _context = context;
        }

        private readonly IProductRepository _productRepository = null!;
        IProductRepository IUoW.Product => this._productRepository ?? new ProductRepository(/*TODO aqui va el context*/);


 
        public async Task<int> SaveChanges()
        {
            // TODO awit _context.SaveChangesAsync();
            return 1;
        }



        public void Dispose()
        {
            // _context.Dispose;
        }
    }
}
