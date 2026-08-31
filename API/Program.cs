using API.Data;
using Microsoft.EntityFrameworkCore;
using API.Middleware;

// ✅ FIX: Pass the current directory safely inside WebApplicationOptions
var builder = WebApplication.CreateBuilder(new WebApplicationOptions
{
    Args = args,
    ContentRootPath = Directory.GetCurrentDirectory()
});

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddDbContext<StoreContext>(opt =>
{
    opt.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"),

        sqlOptions =>
        {
            sqlOptions.EnableRetryOnFailure(maxRetryCount: 5,
                maxRetryDelay: TimeSpan.FromSeconds(30),
                errorNumbersToAdd: null);
        }
    );
});

builder.Services.AddCors();
builder.Services.AddTransient<ExceptionMiddleware>();
var app = builder.Build();
app.UseMiddleware<ExceptionMiddleware>();

app.UseDefaultFiles();
app.UseStaticFiles();

app.UseCors(opt =>
{
    opt.AllowAnyHeader().AllowAnyMethod().WithOrigins("https://localhost:3000", "https://mgportfolio.azurewebsites.net");

});
app.MapControllers();
app.MapFallbackToController("Index", "Fallback");

// ✅ This will compile perfectly now because top-level statements implicitly support await
await DbInitializer.InitDb(app);

app.Run();
