using API.Data;
using API.Extensions;
using API.Middleware;
using Microsoft.EntityFrameworkCore;

namespace API;

public class Program
{
    public static async Task Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddApplicationServices(builder.Configuration);
        builder.Services.AddIdentityServices(builder.Configuration);

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        app.UseMiddleware<ExceptionMiddleware>();
        app.UseCors(x => x.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());//.WithOrigins("http://localhost:4200", "https://localhost:4200"));
        app.UseAuthentication();
        app.UseAuthorization();
        app.MapControllers();

        using var scope = app.Services.CreateScope();
        var services = scope.ServiceProvider;
        try
        {
            var dataContext = services.GetRequiredService<DataContext>();
            await dataContext.Database.MigrateAsync();
            await SeedData.SeedUsers(dataContext);
        }
        catch (Exception ex)
        {
            var loggerService = services.GetRequiredService<ILogger<Program>>();
            loggerService.LogError(ex.Message, "Unsuccessfull DB migration");
        }


        app.Run();
    }
}
