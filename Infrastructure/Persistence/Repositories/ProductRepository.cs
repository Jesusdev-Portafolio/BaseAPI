using Application.Features.Product;
using Domain.Entities;
using Domain.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence.Repositories
{
    public class ProductRepository : IProductRepository
    {
        //TODO declarar contexto
        public ProductRepository()
        {
            //TODO inyecytar contexto
        }

        public async Task<Product> GetProductById(int id)
        {
            return new Product()
            {
                Id = id,
                Description = "Samsung Galaxy s24",
                Price = 1100
            };
        }

        public async Task<int> SaveProduct(Product product)
        {
            return 1;
        }

        public async Task<int> UpdateProduct(Product product)
        {
            return 1;

        }

        public async Task<int> DeleteProduct(int id)
        {
            return 1;
        }
    }

}
