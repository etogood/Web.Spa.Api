namespace Web.Spa.Api.Contracts.Responses;

public class ProductDto
{
    public int Id { get; set; }
    public string Title { get; set; } = null!;
    public string Description { get; set; } = null!;
    public decimal Price { get; set; }
    public string Image { get; set; } = null!;
}
