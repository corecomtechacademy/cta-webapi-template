namespace Cta.WebApi.Template.Models;

public class Customer
{
    public virtual int Id { get; protected set; }

    public virtual string Name { get; set; } = string.Empty;

    public virtual string Email { get; set; } = string.Empty;

    public virtual IList<Order> Orders { get; protected set; } = new List<Order>();
}