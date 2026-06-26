using Cta.WebApi.Template.Models;
using FluentNHibernate.Mapping;

namespace Cta.WebApi.Template.Data.Mappings;

public class OrderMap : ClassMap<Order>
{
    public OrderMap()
    {
        Id(order => order.Id);

        Map(order => order.ProductName)
            .Not.Nullable();

        Map(order => order.Total)
            .Not.Nullable();

        References(order => order.Customer)
            .Column("CustomerId")
            .Not.Nullable();
    }
}