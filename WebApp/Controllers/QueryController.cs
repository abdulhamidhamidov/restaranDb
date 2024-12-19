using Domain;
using Infrostructure.Responce;
using Infrostructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers;
[ApiController]
[Route("[controller]")]
public class QueryController(IQueryService queryService): ControllerBase
{
    [HttpGet("/Get-Customers-By-Name")]
    public async Task<Response<List<Customer>>> GetCustomersByName(string name)
    {
        return await queryService.GetCustomersByName(name);
    }
    [HttpGet("/Get-Order-By-Customer-Id")]
    public async Task<Response<List<Order>>> GetOrderByCustomerId(int customerId)
    {
        return await queryService.GetOrderByCustomerId(customerId);
    }
    [HttpGet("/Get-Empty-Tables")]

    public async Task<Response<List<Table>>> GetEmptyTables()
    {
        return await queryService.GetEmptyTables();
    }
[HttpPut]
    public async Task<Response<bool>> UpdateTableStatus(int tableId)
    {
        return await queryService.UpdateTableStatus(tableId);
    }
[HttpDelete]
    public async Task<Response<bool>> DeleteCustomerById(int id)
    {
        return await queryService.DeleteCustomerById(id);
    }
}