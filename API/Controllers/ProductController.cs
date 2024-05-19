using Application.Features.Product;
using Application.Features.Product.Commands;
using Application.Features.Product.Queries;
using Contracts.Products;
using Contracts.Products.Requests;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class ProductController  : BaseApiController
    {
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductResponse>> GetProductById(int id)
        {
            GetProductByIdQuery query = new(Id: id);
            ProductResult result = await Mediator!.Send(query);
            ProductResponse response = Mapper!.Map<ProductResponse>(result);

            return Ok(response);
        }

        [HttpGet]
        public async Task<ActionResult<ProductResponse>> GetAllProducts(GetAllProductsRequest request)
        {
            GetAllProductsQuery query = Mapper!.Map<GetAllProductsQuery>(request);
            List<ProductResult> result = await Mediator!.Send(query);
            List<ProductResponse> response = Mapper!.Map<List<ProductResponse>>(result);

            return Ok(response);
        }

        [HttpPost] 
        public async Task<ActionResult<ProductResponse>> CreateProduct(CreateProductRequest request)
        {
            CreateProductCommand command = Mapper!.Map<CreateProductCommand>(request);
            ProductResult result = await Mediator!.Send(command);
            ProductResponse response = Mapper!.Map<ProductResponse>(result);
            
            return Ok(response);
        }

        [HttpPut]
        public async Task<ActionResult<ProductResponse>> UpdateProduct(UpdateProductRequest request)
        {
            UpdateProductCommand command = Mapper!.Map<UpdateProductCommand>(request);
            ProductResult result = await Mediator!.Send(command);
            ProductResponse response = Mapper!.Map<ProductResponse>(result);

            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ProductResponse>> DeleteProduct(int id)
        {
            DeleteProductCommand command = new(Id: id);
            int result = await Mediator!.Send(command);
       
            return Ok(result);
        }

    }
}
