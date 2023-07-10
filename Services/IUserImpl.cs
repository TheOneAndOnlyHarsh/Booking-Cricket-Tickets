using Microsoft.AspNetCore.Http.HttpResults;
using User_Lib;
using WebApp.Models;
using WebApp.Models.DTO;
using WebApp.Services.IServices;

namespace WebApp.Services
{
    public class IUserImpl : BaseService, IUserService
    {
        private readonly IHttpClientFactory _clientFactory;
        private string userUrl;

        public IUserImpl(IHttpClientFactory clientFactory, IConfiguration configuration) : base(clientFactory)
        {
            _clientFactory = clientFactory;
            userUrl = configuration.GetValue<string>("ServiceUrl:UsersAPI");
        }

        public Task<T> CreateAsync<T>(UserCreateDTO createDTO , string token)
        {
            return SendAsync<T>(new APIRequest()
            {

                ApiType = SD.ApiType.POST,
                data = createDTO,
                ApiUrl = userUrl + "/api/user",
                Token = token
            });
        }

      public  Task<T> DeleteAsync<T>(int id , string token)
        {
            return SendAsync<T>(new APIRequest()
            {

                ApiType = SD.ApiType.DELETE,
               
                ApiUrl = userUrl + "/api/user/" + id,
                Token = token
            });
        }

       
        //
       public Task<T> GetAllAsync<T>(string token)
        {
            return SendAsync<T>(new APIRequest()
            {

                ApiType = SD.ApiType.GET,
                ApiUrl = userUrl + "/api/user",
                Token = token
            });
        }

        public Task<T> GetAsync<T>(int id, string token)
        {
            return SendAsync<T>(new APIRequest()
            {

                ApiType = SD.ApiType.GET,

                ApiUrl = userUrl + "/api/user/" + id,
                Token = token
            });
        }

        public Task<T> UpdateAsync<T>(UserUpdateDTO updateDTO, string token)
        {
            return SendAsync<T>(new APIRequest()
            {

                ApiType = SD.ApiType.PUT,
                data = updateDTO,
                ApiUrl = userUrl + "api/user/"+ updateDTO.Id ,
                Token = token
            });
        }
    }
}
