using System.Net;
using Dapper;
using Domain;
using Infrostructure.DataContext;
using Infrostructure.Responce;

namespace Infrostructure.Services;

public class MenuItemService(IDapperContext dapperContext): IMenuItemService
{
    public async Task<Response<bool>> Create(Menultem menuItem)
    {
        using var connection = dapperContext.Connection();
        var sql = "insert into  MenuItems (Name, Price, Category) values (@Name, @Price, @Category);\n";
        var res = await connection.ExecuteAsync(sql,menuItem);
        if (res > 0) return new Response<bool>(res!=0);
        return new Response<bool>(HttpStatusCode.NotFound, "Not Found");
    }

    public async Task<Response<List<Menultem>>> GetAll()
    {
        using var connection = dapperContext.Connection();
        var sql = "select * from MenuItems;";
        var res = (await connection.QueryAsync<Menultem>(sql)).ToList();
        return new Response<List<Menultem>>(res);
    }
}