using System.Diagnostics;
using System.Net;
using Dapper;
using Domain;
using Infrostructure.DataContext;
using Infrostructure.Responce;

namespace Infrostructure.Services;

public class CustomerService(IDapperContext dapperContext): ICustomerService
{
    public async Task<Response<bool>> Create(Customer customer)
    {
        using var connection = dapperContext.Connection();
        var sql = "insert into Customers(Name, PhoneNumber) values (@Name,@PhoneNumber);";
        var res = await connection.ExecuteAsync(sql,customer);
        if (res > 0) return new Response<bool>(res!=0);
        return new Response<bool>(HttpStatusCode.NotFound, "Not Found");
    }

    public async Task<Response<Customer>> GetByPhoneBumber(string phoneNumber)
    {
        using var connection = dapperContext.Connection();
        var sql = "select * from Customers;";
        var res = await connection.QuerySingleAsync<Customer>(sql,new {PhoneNumber= phoneNumber});
        if (res != null) return new Response<Customer>(res);
        return new Response<Customer>(HttpStatusCode.NotFound, "Not Found");
    }

    public async Task<Response<List<Customer>>> GetAll()
    {
        using var connection = dapperContext.Connection();
        var sql = "select * from Customers";
        var res = (await connection.QueryAsync<Customer>(sql)).ToList();
         return new Response<List<Customer>>(res);
    }
}