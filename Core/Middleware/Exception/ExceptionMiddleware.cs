using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Core.Middleware.Exception
{
    public class ExceptionMiddleware
    {
        RequestDelegate _next;

        public ExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }



        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (System.Exception e)
            {
                await HandleExceptionAsync(httpContext,e);
            }

        }



        private Task HandleExceptionAsync(HttpContext httpContext, System.Exception e)
        {
            httpContext.Response.ContentType = "application/json";
            httpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

            string message = "Internal Server Error";

            if (e.GetType()==typeof(ValidationException))
            {
                message = "Bad Request";
                httpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                IEnumerable<ValidationFailure> validationFailures = ((ValidationException)e).Errors;

                return httpContext.Response.WriteAsync(new ValidationErrorDetails()
                {
                    CodeStatus = 400,
                    ErrorMessage = message,
                    ValidationErrors = validationFailures
                }.ToString());
            }



            if (e.GetType()==typeof(UnauthorizedAccessException))
            {
                message = "Yetkisiz";
                httpContext.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
                return httpContext.Response.WriteAsync(new ErrorDetails()
                {
                    CodeStatus = httpContext.Response.StatusCode,
                    ErrorMessage = message,
                }.ToString());
            }



            return httpContext.Response.WriteAsync(new ErrorDetails()
            {
                CodeStatus = httpContext.Response.StatusCode,
                ErrorMessage = message
            }.ToString());


        }
    }
}
