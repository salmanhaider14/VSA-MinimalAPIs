namespace VSAMinimalApi.Features.Books.UpdateBook;

public static  class UpdateBookEndpoint
{
    internal static void MapUpdateBook(this IEndpointRouteBuilder app) =>
        app.MapPut("/{bookId}", UpdateBookHandler.Handler)
            .Produces(statusCode:204);
}