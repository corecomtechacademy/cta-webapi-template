using Cta.WebApi.Template.Models;
using NHibernate;
using NHibernate.Linq;

namespace Cta.WebApi.Template.Repositories;

public class CustomerRepository(ISessionFactory sessionFactory) : ICustomerRepository
{
    public async Task<List<CustomerResponse>> GetAll()
    {
        using var session = sessionFactory.OpenSession();

        var customers = await session.Query<Customer>()
            .FetchMany(customer => customer.Orders)
            .ToListAsync();

        return customers
            .Select(MapToResponse)
            .ToList();
    }

    public async Task<CustomerResponse?> GetById(int id)
    {
        using var session = sessionFactory.OpenSession();

        var customer = await session.Query<Customer>()
            .FetchMany(customer => customer.Orders)
            .FirstOrDefaultAsync(customer => customer.Id == id);

        return customer is null ? null : MapToResponse(customer);
    }

    public async Task<CustomerResponse> Create(Customer customer)
    {
        using var session = sessionFactory.OpenSession();
        using var transaction = session.BeginTransaction();

        foreach (var order in customer.Orders)
        {
            order.Customer = customer;
        }

        await session.SaveAsync(customer);
        await transaction.CommitAsync();

        return MapToResponse(customer);
    }

    private static CustomerResponse MapToResponse(Customer customer)
    {
        return new CustomerResponse(
            customer.Id,
            customer.Name,
            customer.Email,
            customer.Orders
                .Select(order => new OrderResponse(
                    order.Id,
                    order.ProductName,
                    order.Total))
                .ToList()
        );
    }
}