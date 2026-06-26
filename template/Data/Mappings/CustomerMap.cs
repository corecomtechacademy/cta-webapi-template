using Cta.WebApi.Template.Models;
using FluentNHibernate.Mapping;

namespace Cta.WebApi.Template.Data.Mappings;

public class CustomerMap : ClassMap<Customer>
{
    public CustomerMap()
    {
        Id(customer => customer.Id);

        Map(customer => customer.Name)
            .Not.Nullable();

        Map(customer => customer.Email)
            .Not.Nullable();

        HasMany(customer => customer.Orders)
            .Cascade.AllDeleteOrphan()
            .Inverse();
    }
}