using Domain;
using Infrostructure.Responce;

namespace Infrostructure.Services;

public interface ITableService
{
     Task<Response<List<TableAndStatus>>> GetTableWithStatus();
     Task<Response<bool>> OccupiedStatusByTableId(int tableId);
     Task<Response<bool>> EmptyStatusByTableId(int tableId);
     
}