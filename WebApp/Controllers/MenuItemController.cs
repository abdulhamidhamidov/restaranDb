using Domain;
using Infrostructure.Responce;
using Infrostructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers;

[ApiController]
[Route("[controller]")]
public class MenuItemController(IMenuItemService menuItemService) : ControllerBase
{
    [HttpPost]
    public async Task<Response<bool>> Create(Menultem menuItem)
    {
        return await menuItemService.Create(menuItem);
    }
    [HttpGet]
    public async Task<Response<List<Menultem>>> GetAll()
    {
        return await menuItemService.GetAll();
    }

}