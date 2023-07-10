using System.Linq.Expressions;
using WebApp.Models.DTO;

namespace WebApp.Services.IServices
{
    public interface IUserService 
    {
        Task<T> GetAllAsync<T>(string token);
        Task<T> GetAsync<T>(int id , string token);
        Task<T> CreateAsync<T>(UserCreateDTO createDTO, string token);
        Task<T> UpdateAsync<T>(UserUpdateDTO updateDTO , string token);

        Task<T> DeleteAsync<T>(int id , string token);

    }
}
