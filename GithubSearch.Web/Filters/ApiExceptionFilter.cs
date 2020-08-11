using GithubSearch.Core.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.StaticFiles;
using System.Net;
using System.Text.Json;

namespace GithubSearch.Web.Filters
{
    public class ApiExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            context.HttpContext.Response.ContentType = new FileExtensionContentTypeProvider().Mappings[".json"];

            var appValidation = context.Exception as AppValidationException;
            if (appValidation != null)
            {
                foreach (var error in appValidation.Failures)
                {
                    context.ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
                }
                context.HttpContext.Response.StatusCode = (int)HttpStatusCode.UnprocessableEntity;
                var validationFaliures = JsonSerializer.Serialize(new
                {
                    Failures = appValidation.Failures
                });
                context.Result = new JsonResult(validationFaliures);
                return;
            }


            context.HttpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            context.Result = new JsonResult(new
            {
                ErrorMsg = HttpStatusCode.InternalServerError.ToString()
            });
            return;
        }
    }
}
