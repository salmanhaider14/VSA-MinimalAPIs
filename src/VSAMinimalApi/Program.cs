
using FluentValidation;
using VSAMinimalApi.Database;
using VSAMinimalApi.Features.Books;
using Microsoft.EntityFrameworkCore;
using Scalar.AspNetCore;
using VSAMinimalApi.Features.ExceptionHandling;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();
builder.Services.AddDbContext<MyContext>(context => context.UseInMemoryDatabase("booksdb"));
builder.Services.AddValidatorsFromAssemblyContaining(typeof(Program));
builder.Services.AddMemoryCache();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference();
}

app.UseHttpsRedirection();
app.UseExceptionHandling();
app.MapBookEndpoints();
app.Run();


