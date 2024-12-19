using System.Net;
using Dapper;
using Domain;
using Infrostructure.DataContext;
using Infrostructure.Responce;

namespace Infrostructure.Services;

public class QueryService(IDapperContext dapperContext) : IQueryService
{
    public async Task<Response<List<Customer>>> GetCustomersByName(string name)
    {
        using var connection = dapperContext.Connection();
        var sql = "select * from Customers where Name=@Name;";
        var res = (await connection.QueryAsync<Customer>(sql)).ToList();
        return new Response<List<Customer>>(res);
    }

    public async Task<Response<List<Order>>> GetOrderByCustomerId(int customerId)
    {
        using var connection = dapperContext.Connection();
        var sql = "select * from Orders o where o.CustomerId=@CustomerId;";
        var res = (await connection.QueryAsync<Order>(sql)).ToList();
        return new Response<List<Order>>(res);
    }

    public async Task<Response<List<Table>>> GetEmptyTables()
    {
        using var connection = dapperContext.Connection();
        var sql = "select * from Tables where IsOccupied=true;";
        var res = (await connection.QueryAsync<Table>(sql)).ToList();
        return new Response<List<Table>>(res);
    }

    public async Task<Response<bool>> UpdateTableStatus(int tableId)
    {
        using var connection = dapperContext.Connection();
        var sql = "update Orders SET Status='под ремонт' WHERE CustomerId=@CustomerId;";
        var res = await connection.ExecuteAsync(sql,new {TableId=tableId});
        if (res > 0) return new Response<bool>(res!=0);
        return new Response<bool>(HttpStatusCode.NotFound, "Not Found");
    }

    public async Task<Response<bool>> DeleteCustomerById(int id)
    {
        using var connection = dapperContext.Connection();
        var sql = "delete from Customers where Id=@Id AND 0=(select count(t.IsOccupied) from Orders o join Tables t on t.Id=o.TableId where t.IsOccupied=false)";
        var res = await connection.ExecuteAsync(sql,new {Id=id});
        if (res > 0) return new Response<bool>(res!=0);
        return new Response<bool>(HttpStatusCode.NotFound, "Not Found");
    }
}