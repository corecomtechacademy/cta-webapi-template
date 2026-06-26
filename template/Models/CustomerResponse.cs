namespace Cta.WebApi.Template.Models;

public record CustomerResponse(
    int Id,
    string Name,
    string Email,
    List<OrderResponse> Orders
);