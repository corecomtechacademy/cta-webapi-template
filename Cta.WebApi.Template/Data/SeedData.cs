using Cta.WebApi.Template.Models;
using NHibernate;
using NHibernate.Linq;

namespace Cta.WebApi.Template.Data;

public static class SeedData
{
    public static async Task Initialise(ISessionFactory sessionFactory)
    {
        using var session = sessionFactory.OpenSession();

        if (await session.Query<Customer>().AnyAsync())
        {
            return;
        }

        using var transaction = session.BeginTransaction();

        var alice = new Customer
        {
            Name = "Alice",
            Email = "alice@example.com"
        };

        alice.Orders.Add(new Order
        {
            ProductName = "Laptop",
            Total = 999.99m,
            Customer = alice
        });

        var bob = new Customer
        {
            Name = "Bob",
            Email = "bob@example.com"
        };

        await session.SaveAsync(alice);
        await session.SaveAsync(bob);

        await transaction.CommitAsync();
    }
}