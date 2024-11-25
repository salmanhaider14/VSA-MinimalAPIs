using VSAMinimalApi.Features.Books.CreateBook;
using VSAMinimalApi.Features.Books.DeleteBook;
using VSAMinimalApi.Features.Books.GetBook;
using VSAMinimalApi.Features.Books.GetBooks;
using VSAMinimalApi.Features.Books.UpdateBook;

namespace VSAMinimalApi.Features.Books;
public static class BookEndpointHostingExtensions
{ 
    public static void MapBookEndpoints(this WebApplication app)
    {
        var bookGroup = app.MapGroup("/books");
        
        bookGroup.MapGetBooks();
        bookGroup.MapGetBook();
        bookGroup.MapCreateBook();
        bookGroup.MapDeleteBook();
        bookGroup.MapUpdateBook();
    }
}
