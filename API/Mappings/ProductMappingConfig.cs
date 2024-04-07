using Application.Features.Product;
using Application.Features.Product.Commands;
using Application.Features.Product.Queries;
using Contracts.Products;
using Contracts.Products.Requests;
using Mapster;

namespace API.Mappings
{
    public class ProductMappingConfig : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {

            config.NewConfig<GetProductByIdRequest, GetProductByIdQuery>();
            config.NewConfig<GetAllProductsRequest, GetAllProductsQuery>();

            config.NewConfig<CreateProductRequest, CreateProductCommand>();
            config.NewConfig<UpdateProductRequest, UpdateProductCommand>();

            config.NewConfig<ProductResult, ProductResponse>();



        }
    }
}
