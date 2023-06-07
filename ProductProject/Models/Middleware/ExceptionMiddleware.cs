using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System.Net;
using System.Threading.Tasks;

namespace ProductProject.Models.Middleware
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        
        private readonly ILogger<ExceptionMiddleware> _logger;


        public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext httpcontext) 
        {
            try
            {
                await _next(httpcontext);

            }
            catch (System.Exception ex)
            {
                _logger.LogError(ex.Message);

                httpcontext.Response.ContentType = "applicaiton/json";

                httpcontext.Response.StatusCode =(int)HttpStatusCode.InternalServerError;

                //code: 500 message: Error url: 

                var result = Newtonsoft.Json.JsonConvert.SerializeObject( new {code= (int)HttpStatusCode.InternalServerError, message = "Error Occurated", url=httpcontext.Request.Path.Value });

                await httpcontext.Response.WriteAsync(result);
                
            }
            
        }
    }
}
