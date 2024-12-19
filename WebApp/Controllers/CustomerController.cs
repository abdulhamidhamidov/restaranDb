using Domain;
using Infrostructure.Responce;
using Infrostructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers;

[ApiController]
[Route("[controller]")]
public class CustomerController(ICustomerService customerService): ControllerBase
{
    [HttpPost]
    public async Task<Response<bool>> Create(Customer customer)
    {
        return await customerService.Create(customer);
    }
    [HttpGet("/get-by-phonenumber")]
    public async Task<Response<Customer>> GetByPhoneBumber(string phoneNumber)
    {
        return await customerService.GetByPhoneBumber(phoneNumber);
    }
    [HttpGet]
    public async Task<Response<List<Customer>>> GetAll()
    {
        return await customerService.GetAll();
    }
}