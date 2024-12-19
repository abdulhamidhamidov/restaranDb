using Domain;
using Infrostructure.Responce;

namespace Infrostructure.Services;

public interface IOrderService
{
    Task<Response<bool>> Create(Order order);
    Task<Response<bool>> Update(Order order);
    Task<Response<List<Order>>> GetAll();
}