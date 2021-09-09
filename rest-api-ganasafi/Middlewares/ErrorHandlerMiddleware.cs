using Application.exceptions;
using Application.wrappers;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;

namespace rest_api_ganasafi.Middlewares
{
    public class ErrorHandlerMiddleware
    {

        private readonly RequestDelegate _next;

        public ErrorHandlerMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception error)
            {

                var response = context.Response;
                response.ContentType = "application/json";

                var result = new Response<string>()
                {
                    successed = false,
                    message = error?.Message
                };
                switch (error)
                {
                    case ApiException apiException:

                        response.StatusCode = (int)HttpStatusCode.BadRequest;
                        break;

                    case ValidationException validationException:
                        response.StatusCode = (int)HttpStatusCode.BadRequest;
                        result.errors = validationException._errors;
                        break;

                    case KeyNotFoundException keyNotFoundException:
                        response.StatusCode = (int)HttpStatusCode.NotFound;
                        break;
                         
                    default:
                        response.StatusCode = (int)HttpStatusCode.InternalServerError;
                        break;
                }

                await response.WriteAsync(JsonSerializer.Serialize(result));
            }
        }
    }
}
