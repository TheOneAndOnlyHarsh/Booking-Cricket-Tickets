using Microsoft.AspNetCore.Routing.Tree;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Runtime.InteropServices;
using System.Text;
using User_Lib;
using WebApp.Models;
using WebApp.Services.IServices;

namespace WebApp.Services
{
    public class BaseService : IBaseService
    {
        public APIResponse responseModel { get; set; }
        public IHttpClientFactory httpClient { get; set; }
        public BaseService(IHttpClientFactory httpClient) 
        {
            this.responseModel = new();
            this.httpClient = httpClient;   
        }
        public async Task<T>  SendAsync<T>(APIRequest apiRequest)
        {
            try{


                var client = httpClient.CreateClient("UserAPI");
                HttpRequestMessage message = new HttpRequestMessage();
                message.Headers.Add("Accept", "application/json");
                message.RequestUri = new Uri(apiRequest.ApiUrl);
                if(apiRequest.data != null)
                {

                    message.Content = new StringContent(JsonConvert.SerializeObject(apiRequest.data),
                        Encoding.UTF8, "application/json");
                }
                switch (apiRequest.ApiType)
                {
                    case SD.ApiType.POST:
                        message.Method = HttpMethod.Post; 
                        break;
                    case SD.ApiType.PUT:
                        message.Method = HttpMethod.Put; 
                        break;
                    case SD.ApiType.DELETE:
                        message.Method = HttpMethod.Delete;
                        break;
                    default:
                        message.Method = HttpMethod.Get;
                       
                        break;
                }

                HttpResponseMessage apiResponse = null;
                if(!string.IsNullOrEmpty(apiRequest.Token))
                {
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer" ,apiRequest.Token);

                }

                apiResponse = await client.SendAsync(message);

                var apiContent = await apiResponse.Content.ReadAsStringAsync();

                var ApiResponse = JsonConvert.DeserializeObject<T>(apiContent);

                
                return ApiResponse;


            }
            catch (Exception ex) {

                var dto = new APIResponse
                {

                    ErrorMessage = new List<string> { Convert.ToString(ex.Message) },
                    IsSuccess = false,
                };
                var res = JsonConvert.SerializeObject(dto);  
                var APIResponse = JsonConvert.DeserializeObject<T>(res);
                return APIResponse;


            }
        }
    }
}
