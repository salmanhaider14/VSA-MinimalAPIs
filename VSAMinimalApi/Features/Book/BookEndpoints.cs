namespace VSAMinimalApi.Features.Book;
public static class BookEndpoints
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
