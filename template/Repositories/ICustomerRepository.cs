using Cta.WebApi.Template.Models;

namespace Cta.WebApi.Template.Repositories;

public interface ICustomerRepository
{
    Task<List<CustomerResponse>> GetAll();
    Task<CustomerResponse?> GetById(int id);
    Task<CustomerResponse> Create(Customer customer);
}