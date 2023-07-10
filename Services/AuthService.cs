using User_Lib;
using WebApp.Models.DTO;
using WebApp.Models;
using WebApp.Services.IServices;

namespace WebApp.Services 
{ 
public class AuthService : BaseService, IAuthService
{
    private readonly IHttpClientFactory _clientFactory;
    private string villaUrl;

    public AuthService(IHttpClientFactory clientFactory, IConfiguration configuration) : base(clientFactory)
    {
        _clientFactory = clientFactory;
        villaUrl = configuration.GetValue<string>("ServiceUrl:UsersAPI");

    }

    public Task<T> LoginAsync<T>(LoginRequestDTO obj)
    {
        return SendAsync<T>(new APIRequest()
        {
            ApiType = SD.ApiType.POST,
            data = obj,
            ApiUrl = villaUrl + "/api/UsersAuth/login"
        });
    }

    public Task<T> RegisterAsync<T>(RegisterAdmin obj)
    {
        return SendAsync<T>(new APIRequest()
        {
            ApiType = SD.ApiType.POST,
            data = obj,
            ApiUrl = villaUrl + "/api/UsersAuth/register"
        });
    }

       
    }
}