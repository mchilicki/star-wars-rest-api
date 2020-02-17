using Chilicki.StarWars.Application.Helpers.Exceptions;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Chilicki.StarWars.WebApi.Configurations.ErrorHandling
{
    public class ErrorMiddlewareHandler
    {
        private readonly RequestDelegate next;
        public ErrorMiddlewareHandler(RequestDelegate next)
        {
            this.next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await next(context);
            }
            catch (Exception exception)
            {
                await HandleExceptionAsync(context, exception);
            }
        }

        private Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            var code = HttpStatusCode.InternalServerError;
            if (exception is BadRequestException)
                code = HttpStatusCode.BadRequest;
            if (exception is NotFoundException)
                code = HttpStatusCode.NotFound;
            var errorDto = new ErrorDto()
            {
                Message = exception.Message
            };
            var result = JsonConvert.SerializeObject(errorDto);
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)code;
            return context.Response.WriteAsync(result);
        }
    }
}
