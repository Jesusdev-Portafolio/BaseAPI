namespace Contracts.Products.Requests
{
    public record CreateProductRequest(
        string Description,
        Double Price
        );
}
