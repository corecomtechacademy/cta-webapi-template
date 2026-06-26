namespace Cta.WebApi.Template.Models;

public class Order
{
    public virtual int Id { get; protected set; }

    public virtual string ProductName { get; set; } = string.Empty;

    public virtual decimal Total { get; set; }

    public virtual Customer? Customer { get; set; }
}