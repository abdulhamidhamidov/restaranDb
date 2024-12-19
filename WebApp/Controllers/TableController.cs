using System.Diagnostics.Contracts;
using Domain;
using Infrostructure.Responce;
using Infrostructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers;
[ApiController]
[Route("[controller]")]
public class TableController(ITableService tableService): ControllerBase
{
    [HttpGet("/get-with-status")]
    public async Task<Response<List<TableAndStatus>>> GetTableWithStatus()
    {
        return await tableService.GetTableWithStatus();
    }
    [HttpPut("/Occupied-Status-By-TableId")]
    public async Task<Response<bool>> OccupiedStatusByTableId(int tableId)
    {
        return await tableService.OccupiedStatusByTableId(tableId);
    }
    [HttpPut("/Empty-Status-By-TableId")]
    public async Task<Response<bool>> EmptyStatusByTableId(int tableId)
    {
        return await tableService.EmptyStatusByTableId(tableId);
    }
}