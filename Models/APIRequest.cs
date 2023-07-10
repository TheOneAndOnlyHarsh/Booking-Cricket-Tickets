using Microsoft.AspNetCore.Mvc;
using User_Lib;
using static User_Lib.SD;

namespace WebApp.Models
{
    public class APIRequest
    {

        public ApiType ApiType { get; set; } = ApiType.GET;

        public string ApiUrl { get; set; }  
        public object data { get; set; }  
        
        public string Token { get; set; }
    }
}
