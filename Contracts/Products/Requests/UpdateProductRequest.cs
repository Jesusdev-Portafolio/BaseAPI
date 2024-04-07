namespace Contracts.Products.Requests
{
    public record UpdateProductRequest(
        string Id,
        string Description,
        double Price
        );
}
