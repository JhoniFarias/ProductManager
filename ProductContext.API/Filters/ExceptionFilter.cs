using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using ProductContext.Shared.Exceptions;
using System.Net;

namespace ProductContext.API.Filters
{
    public class ExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            if (context.Exception is InvalidProductException)
                HandleInvalidProductException(context);
            else if (context.Exception is NotFoundProductException)
                HandleNotFoundProductException(context);
            else
               HandleUnknownException(context);
        }

        private void HandleInvalidProductException(ExceptionContext context)
        {
            var validationErrorException = context.Exception as InvalidProductException;

            context.HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
            context.Result = new ObjectResult(new { validationErrorException?.Errors });
        }

        private void HandleNotFoundProductException(ExceptionContext context)
        {
            var validationErrorException = context.Exception as NotFoundProductException;

            context.HttpContext.Response.StatusCode = (int)HttpStatusCode.NotFound;
            context.Result = new ObjectResult(validationErrorException?.Message);
        }

        private void HandleUnknownException(ExceptionContext context)
        {
            context.HttpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            context.Result = new ObjectResult("Erro desconhecido");
        }
    }
}
