using System.Diagnostics.CodeAnalysis;
using System.Net;
using CRIApp.Api.Controllers.Responses;
using CRIApp.Domain.Exceptions;
using Microsoft.AspNetCore.Diagnostics;
using Newtonsoft.Json;

namespace CRIApp.Api.Middlewares;

[ExcludeFromCodeCoverage]
public static class ErrorHandlerExtensions
{
    public static IApplicationBuilder UseErrorHandler(
        this IApplicationBuilder appBuilder)
    {
        return appBuilder.UseExceptionHandler(builder =>
        {
            builder.Run(async context =>
            {
                var exceptionHandlerFeature = context
                    .Features
                    .Get<IExceptionHandlerFeature>();
                var exceptionHandlerPathFeature =
                    context.Features.Get<IExceptionHandlerPathFeature>();

                if (exceptionHandlerFeature != null)
                {
                    if (exceptionHandlerPathFeature?.Error is NotFoundException notFoundException)
                    {
                        var response = new ApiResponse<object>(false);

                        context.Response.StatusCode = (int)HttpStatusCode.NotFound;
                        context.Response.ContentType = "application/json";

                        await context.Response.WriteAsync(JsonConvert.SerializeObject(response));
                    }
                    else if (exceptionHandlerPathFeature?.Error is ValidationException validationException)
                    {
                        var response = new ApiResponse<object>(false, messages: validationException.Errors);

                        context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                        context.Response.ContentType = "application/json";

                        await context.Response.WriteAsync(JsonConvert.SerializeObject(response));
                    }
                    else
                    {
                        var response = new ApiResponse<object>( "Oops, there was a problem. We already notified our team and we are working to solve it.");

                        context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                        context.Response.ContentType = "application/json";

                        await context.Response.WriteAsync(JsonConvert.SerializeObject(response));
                    }
                }
            });
        });
    }
}