namespace Contracts.Products.Requests
{
    public record UpdateProductRequest(
        int Id,
        string Description,
        double Price
        );
}
