namespace StyleMeStore.Server.Contracts.Responses;

public record ProductItemsResponse(IEnumerable<ProductItemDto> ProductItems);

public record ProductItemDto(int Id, string Type, string Size, string Colour, decimal Price, DateOnly AvailableOn);