using Domain;
using Infrostructure.Responce;

namespace Infrostructure.Services;

public interface IMenuItemService
{
    Task<Response<bool>> Create(Menultem menuItem);
    Task<Response<List<Menultem>>> GetAll();
}

