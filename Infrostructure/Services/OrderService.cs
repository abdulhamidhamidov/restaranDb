using System.Net;
using Dapper;
using Domain;
using Infrostructure.DataContext;
using Infrostructure.Responce;

namespace Infrostructure.Services;

public class OrderService(IDapperContext dapperContext): IOrderService
{
    public async Task<Response<bool>> Create(Order order)
    {
        using var connection = dapperContext.Connection();
        var sql = "insert into Orders( CustomerId, TableId, Status) values ( @CustomerId, @TableId, @Status);";
        var res = await connection.ExecuteAsync(sql,order);
        if (res > 0) return new Response<bool>(res!=0);
        return new Response<bool>(HttpStatusCode.NotFound, "Not Found");
    }

    public async Task<Response<bool>> Update(Order order)
    {
        using var connection = dapperContext.Connection();
        var sql = "update Orders set  CustomerId=@CustomerId, TableId=@TableId, Status=@Status WHERE Id=@Id;";
        var res = await connection.ExecuteAsync(sql,order);
        if (res > 0) return new Response<bool>(res!=0);
        return new Response<bool>(HttpStatusCode.NotFound, "Not Found");
    }

    public async Task<Response<List<Order>>> GetAll()
    {
        using var connection = dapperContext.Connection();
        var sql = "SELECT * FROM Orders";
        var res = (await connection.QueryAsync<Order>(sql)).ToList();
        return new Response<List<Order>>(res);  
    }
}