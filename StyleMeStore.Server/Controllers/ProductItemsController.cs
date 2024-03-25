namespace StyleMeStore.Server.Controllers;

[ApiController]
[Route("[controller]")]
public class ProductItemsController(ISender mediator) : ControllerBase
{
    [HttpGet(Name = "ProductItems")]
    public async Task<ProductItemsResponse> ProductItems() => await mediator.Send(new GetProductItemsQuery());
}