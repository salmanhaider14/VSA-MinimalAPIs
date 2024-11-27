using System.Net;
using System.Net.Http.Json;
using BlazorWASM.Models; // Assume models like SingleBook, CreateBookCommand, UpdateBookCommand, etc., are in this namespace.
using System.Text.Json;

namespace BlazorWASM.Services;

/// <summary>
/// Service for managing book-related API operations.
/// </summary>
public class BookService
{
    private readonly HttpClient _httpClient;

    public BookService(IHttpClientFactory httpClientFactory)
    {
        _httpClient = httpClientFactory.CreateClient("api");
    }

    /// <summary>
    /// Gets a paginated list of books.
    /// </summary>
    /// <param name="pageNumber">The page number to retrieve.</param>
    /// <param name="pageSize">The number of books per page.</param>
    /// <returns>A list of books.</returns>
    public async Task<List<Book>> GetBooksAsync(int pageNumber = 1, int pageSize = 10)
    {
        var response = await _httpClient.GetAsync("/books");
        response.EnsureSuccessStatusCode();
        return await response.Content.ReadFromJsonAsync<List<Book>>() ?? new List<Book>();
    }

    /// <summary>
    /// Gets a single book by its ID.
    /// </summary>
    /// <param name="bookId">The ID of the book.</param>
    /// <returns>The book if found; otherwise, null.</returns>
    public async Task<Book?> GetBookByIdAsync(int bookId)
    {
        var response = await _httpClient.GetAsync($"/books/{bookId}");
        if (response.IsSuccessStatusCode)
        {
            return await response.Content.ReadFromJsonAsync<Book>();
        }
        return null;
    }

    /// <summary>
    /// Creates a new book.
    /// </summary>
    /// <param name="createBookCommand">The command containing book details.</param>
    /// <returns>The created book.</returns>
    public async Task<Book?> CreateBookAsync(CreateBookCommand createBookCommand)
    {
        var response = await _httpClient.PostAsJsonAsync("/books", createBookCommand);
        if (response.IsSuccessStatusCode)
        {
            return await response.Content.ReadFromJsonAsync<Book>();
        }

        var errorContent = await response.Content.ReadAsStringAsync();
        throw new ApplicationException($"Failed to create book: {errorContent}");
    }

    /// <summary>
    /// Updates an existing book.
    /// </summary>
    /// <param name="bookId">The ID of the book to update.</param>
    /// <param name="updateBookCommand">The command containing updated book details.</param>
    /// <returns>The updated book.</returns>
    public async Task<bool> UpdateBookAsync(int bookId, UpdateBookCommand updateBookCommand)
    {
        var response = await _httpClient.PutAsJsonAsync($"/books/{bookId}", updateBookCommand);
        if (response.IsSuccessStatusCode)
        {
            return true;
        }

        var errorContent = await response.Content.ReadAsStringAsync();
        throw new ApplicationException($"Failed to update book: {errorContent}");
    }

    /// <summary>
    /// Deletes a book by its ID.
    /// </summary>
    /// <param name="bookId">The ID of the book to delete.</param>
    /// <returns>True if the book was deleted; otherwise, false.</returns>
    public async Task<bool> DeleteBookAsync(int bookId)
    {
        var response = await _httpClient.DeleteAsync($"/books/{bookId}");
        return response.IsSuccessStatusCode;
    }
}
