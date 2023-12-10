using System.Net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using TwitterClone.Exeptions;

namespace TwitterClone.Filter;

public class ExeptionFilter : IExceptionFilter
{
    public void OnException(ExceptionContext context)
    {
        if (context.Exception is BaseException)
        {
            ExceptionHandler(context);
        }
        else
        {
            context.HttpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            context.Result = new ObjectResult("Ocorreu um erro inesperado 😒");
        }
    }

    private void ExceptionHandler(ExceptionContext context)
    {
        if (context.Exception is TwitterCloneExeption)
        {
            var requestException = context.Exception as TwitterCloneExeption;

            context.HttpContext.Response.StatusCode = requestException.StatusCode;

            context.Result = new ObjectResult(requestException.ExceptionMessage);
        }
    }

}
