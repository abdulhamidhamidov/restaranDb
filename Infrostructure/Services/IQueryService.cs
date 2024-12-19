using Domain;
using Infrostructure.Responce;

namespace Infrostructure.Services;

public interface IQueryService
{
    Task<Response<List<Customer>>> GetCustomersByName(string name);
    Task<Response<List<Order>>> GetOrderByCustomerId(int customerId);
    Task<Response<List<Table>>>  GetEmptyTables();
    Task<Response<bool>> UpdateTableStatus(int tableId);
    Task<Response<bool>> DeleteCustomerById(int id);
}