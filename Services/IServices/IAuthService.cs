using WebApp.Models.DTO;

namespace WebApp.Services.IServices
{
    public interface IAuthService
    {
        
        Task<T> LoginAsync<T>(LoginRequestDTO objToCreate);
        Task<T> RegisterAsync<T>(RegisterAdmin objToCreate);
    }

}
