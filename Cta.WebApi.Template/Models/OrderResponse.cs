namespace Cta.WebApi.Template.Models;

public record OrderResponse(
    int Id,
    string ProductName,
    decimal Total
);