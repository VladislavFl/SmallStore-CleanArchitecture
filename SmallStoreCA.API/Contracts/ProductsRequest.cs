namespace SmallStoreCA.API.Contracts
{
    public record ProductsRequest(
        string Name,
        string Description,
        decimal Price);
}
