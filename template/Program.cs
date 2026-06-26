using Cta.WebApi.Template.Data;
using Cta.WebApi.Template.Repositories;
using NHibernate;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddSingleton<ISessionFactory>(_ =>
{
    var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

    if (connectionString is null)
    {
        throw new InvalidOperationException("Connection string 'DefaultConnection' was not found.");
    }

    return NHibernateHelper.CreateSessionFactory(connectionString);
});

builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();

builder.Services.AddOpenApi();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var sessionFactory = scope.ServiceProvider.GetRequiredService<ISessionFactory>();
    await SeedData.Initialise(sessionFactory);
}

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.MapControllers();

app.Run();