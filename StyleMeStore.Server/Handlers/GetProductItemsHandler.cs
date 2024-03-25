namespace StyleMeStore.Server.Handlers;

public class GetProductItemsHandler(ILogger<GetProductItemsHandler> logger, ApplicationDbContext dbContext) : IRequestHandler<GetProductItemsQuery, ProductItemsResponse>
{
    public async Task<ProductItemsResponse> Handle(GetProductItemsQuery request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Generating 20 random product items");
        await GenerateRandomProductItems(cancellationToken);
        
        var productItems = await dbContext.ProductItems
            .Select(t => new ProductItemDto(t.Id, t.Type, t.Size, t.Colour, t.Price, t.AvailableOn))
            .OrderBy(t => t.AvailableOn)
            .ToListAsync(cancellationToken);
        
        return new ProductItemsResponse(productItems);
    }

    private async Task GenerateRandomProductItems(CancellationToken cancellationToken)
    {
        var productItemSpec = new Faker<ProductItem>()
                .RuleFor(t => t.Type, t => t.Commerce.Product())
                .RuleFor(t => t.Size, t => t.Commerce.ProductMaterial())
                .RuleFor(t => t.Colour, t => t.Commerce.Color())
                .RuleFor(t => t.Price, t => decimal.Parse(t.Commerce.Price()))
                .RuleFor(t => t.AvailableOn, t => t.Date.FutureDateOnly(1, DateOnly.FromDateTime(DateTime.Now)));
        
        var randomProductItems = productItemSpec.Generate(20);

        dbContext.ProductItems.AddRange(randomProductItems);

        await dbContext.SaveChangesAsync(cancellationToken);
    }
}
