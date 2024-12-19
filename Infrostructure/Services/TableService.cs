using System.Net;
using Dapper;
using Domain;
using Infrostructure.DataContext;
using Infrostructure.Responce;

namespace Infrostructure.Services;

public class TableService(IDapperContext dapperContext): ITableService
{
    public async Task<Response<List<TableAndStatus>>> GetTableWithStatus()
    {
        using var connection = dapperContext.Connection();
        var sql = "select t.Id,t.TableNumber,t.IsOccupied,o.Status from Tables t join Orders o on o.TableId=Id";
        var res = await connection.QueryAsync<TableAndStatus>(sql);
        return new Response<List<TableAndStatus>>(res.ToList());
    }
    public async Task<Response<bool>> OccupiedStatusByTableId(int tableId)
    {
        using var connection = dapperContext.Connection();
        var sql = "update Orders set Status='занят' where TableId=@TableId;";
        var res = await connection.ExecuteAsync(sql,new {TableId = tableId});
        if (res != 0) return new Response<bool>(res!=0);
        return new Response<bool>(HttpStatusCode.NotFound, "Not Found");
    }

    public async Task<Response<bool>> EmptyStatusByTableId(int tableId)
    {
        using var connection = dapperContext.Connection();
        var sql = "update Orders set Status='свободен' where TableId=@TableId;";
        var res = await connection.ExecuteAsync(sql,new {TableId = tableId});
        if (res != 0) return new Response<bool>(res!=0);
        return new Response<bool>(HttpStatusCode.NotFound, "Not Found");
    }
}