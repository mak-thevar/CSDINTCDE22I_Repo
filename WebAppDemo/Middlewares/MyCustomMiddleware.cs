using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace WebAppDemo.Middlewares
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class MyCustomMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<MyCustomMiddleware> logger;

        public MyCustomMiddleware(RequestDelegate next, ILogger<MyCustomMiddleware> logger)
        {
            _next = next;
            this.logger = logger;
        }

        public Task Invoke(HttpContext httpContext)
        {
            //Preprocess
            var req = httpContext.Request;
            logger.LogInformation("Executing request path : {0}", req.Path);
            logger.LogInformation("Executing Method : {0}",req.Method);
            

            return _next(httpContext);
        }
    }

   
}
