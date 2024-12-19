using Domain;
using Infrostructure.Responce;

namespace Infrostructure.Services;

public interface ICustomerService
{
    Task<Response<bool>> Create(Customer customer);
    Task<Response<Customer>> GetByPhoneBumber(string phoneNumber);
    Task<Response<List<Customer>>> GetAll();
}