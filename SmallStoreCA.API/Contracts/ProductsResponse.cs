namespace SmallStoreCA.API.Contracts
{
    public record ProductsResponse(
        Guid Id,
        string Name,
        string Description,
        decimal Price);
}
