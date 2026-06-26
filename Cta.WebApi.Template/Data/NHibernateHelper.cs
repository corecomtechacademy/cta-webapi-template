using Cta.WebApi.Template.Data.Mappings;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Tool.hbm2ddl;

namespace Cta.WebApi.Template.Data;

public static class NHibernateHelper
{
    public static ISessionFactory CreateSessionFactory(string connectionString)
    {
        return Fluently.Configure()
            .Database(SQLiteConfiguration.Standard.ConnectionString(connectionString))
            .Mappings(mappings =>
            {
                mappings.FluentMappings.AddFromAssemblyOf<CustomerMap>();
            })
            .ExposeConfiguration(configuration =>
            {
                new SchemaUpdate(configuration).Execute(false, true);
            })
            .BuildSessionFactory();
    }
}