using Cta.WebApi.Template.Models;
using Cta.WebApi.Template.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Cta.WebApi.Template.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CustomersController(ICustomerRepository customerRepository) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<List<CustomerResponse>>> GetAll()
    {
        return await customerRepository.GetAll();
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<CustomerResponse>> GetById(int id)
    {
        var customer = await customerRepository.GetById(id);

        return customer is null ? NotFound() : customer;
    }

    [HttpPost]
    public async Task<ActionResult<CustomerResponse>> Create(Customer customer)
    {
        var createdCustomer = await customerRepository.Create(customer);

        return CreatedAtAction(
            nameof(GetById),
            new { id = createdCustomer.Id },
            createdCustomer
        );
    }
}