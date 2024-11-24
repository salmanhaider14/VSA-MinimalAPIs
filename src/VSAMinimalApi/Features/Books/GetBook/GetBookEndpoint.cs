
namespace VSAMinimalApi.Features.Books.GetBook;

public static class GetBookEndpoint
{
    internal static void MapGetBook(this IEndpointRouteBuilder app) =>
        app.MapGet("/{bookId}", GetBookHandler.Handler)
            .Produces<GetBookResponse>();
}