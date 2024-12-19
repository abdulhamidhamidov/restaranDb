using Domain;
using Infrostructure.Responce;
using Infrostructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers;
[ApiController]
[Route("[controller]")]
public class OrderController(IOrderService orderService): ControllerBase
{
    [HttpPost]
    public async Task<Response<bool>> Create(Order order)
    {
        return await orderService.Create(order);
    }
    [HttpPut]
    public async Task<Response<bool>> Update(Order order)
    {
        return await orderService.Update(order);
    }
    [HttpGet]
    public async Task<Response<List<Order>>> GetAll()
    {
        return await orderService.GetAll();
    }
}