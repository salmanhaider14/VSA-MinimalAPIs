using Microsoft.AspNetCore.Diagnostics;

namespace VSAMinimalApi.Features.ExceptionHandling;

/// <summary>
///     Provides extension methods for configuring exception handling middleware.
/// </summary>
public static class ExceptionHandlingMiddleware
{
    /// <summary>
    ///     Configures the application to use centralised exception handling.
    /// </summary>
    /// <param name="app">The <see cref="WebApplication"/> instance to configure.</param>
    public static void UseExceptionHandling(this WebApplication app)
    {
        app.UseExceptionHandler(appError =>
        {
            appError.Run(async context =>
            {
                context.Response.StatusCode = 500;
                context.Response.ContentType = "application/json";

                var contextFeature = context.Features.Get<IExceptionHandlerFeature>();
                if (contextFeature is not null)
                {
                    app.Logger.LogError("Error: {error}", contextFeature.Error);

                    await context.Response.WriteAsJsonAsync(new
                    {
                        StatusCode = context.Response.StatusCode,
                        Message = "Internal Server Error"
                    });
                }
            });
        });
    }
}