using System.Net;
using System.Text.Json;
using Musicfy.Core.Model;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using static System.Enum;

namespace Musicfy.Core.Exceptions
{
    public static class ExceptionMiddlewareExtensions
    {
        public static void ConfigureExceptionHandler(this IApplicationBuilder app)
        {
            app.UseExceptionHandler(appError =>
            {
                appError.Run(async context =>
                {
                    context.Response.ContentType = "application/json";

                    HttpStatusCode httpCode = HttpStatusCode.InternalServerError;
                    string? userFriendlyError = null;
                    string? moreInformation = null;

                    IExceptionHandlerFeature? contextFeature = context.Features.Get<IExceptionHandlerFeature>();
                    if (contextFeature != null)
                    {
                        Exception? ex = contextFeature.Error;
                        ex = ex is ChallengeHandledException exception ? exception.HandledException : ex;
                        if (ex != null)
                        {
                            if (ex is ChallengeException challengeException && IsDefined(typeof(HttpStatusCode), challengeException.Code))
                                httpCode = (HttpStatusCode)challengeException.Code;

                            userFriendlyError = ex.Message;
                            moreInformation = "StackTrace:" + ex.StackTrace;
                        }
                    }

                    context.Response.StatusCode = (int)httpCode;
                    ErrorResponseViewModel errorObject = new()
                    {
                        HttpCode = (int)httpCode,
                        HttpMessage = GetName(typeof(HttpStatusCode), context.Response.StatusCode),
                        UserFriendlyError = userFriendlyError,
                        MoreInformation = moreInformation
                    };

                    await context.Response.WriteAsync(JsonSerializer.Serialize(errorObject));
                });
            });
        }
    }
}
