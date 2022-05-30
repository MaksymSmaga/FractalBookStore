using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace FractalBookStore.Web
{
    public class ExceptionFilter : IExceptionFilter
    {
        private readonly IWebHostEnvironment _webHostEnvironment;

        public ExceptionFilter(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }
        public void OnException(ExceptionContext context)
        {
            if (context.Exception.TargetSite.Name == "ThrowNoElementsException")
            {
                context.Result = new ViewResult
                {
                    ViewName = "PageIsNotFound",
                    StatusCode = 404,
                };
            }
        }
    }
}
