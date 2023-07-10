using System.Net;

namespace WebApp.Models
{
    // this class is used for API responses.
    public class APIResponse
    {

        public HttpStatusCode statusCode { get; set; }

        public bool IsSuccess { get; set; } 

        public List<string> ErrorMessage { get; set; }

        public object Results { get; set; }
    }
}
