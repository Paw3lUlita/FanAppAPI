using FanClubAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace FanClubAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddDbContext<FanClubContext>(options =>
                options.UseMySql(
                 builder.Configuration.GetConnectionString("FanClubDatabase"),
                 ServerVersion.AutoDetect(builder.Configuration.GetConnectionString("FanClubDatabase"))
                    ));

            builder.Services.AddControllers().AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles;
            });
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowAll", builder =>
                {
                    builder.AllowAnyOrigin()
                           .AllowAnyMethod()
                           .AllowAnyHeader();
                });
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            // Ensure CORS middleware is applied before Authorization
            app.UseCors("AllowAll");

            // Handle preflight requests
            app.Use(async (context, next) =>
            {
                if (context.Request.Method == "OPTIONS")
                {
                    context.Response.StatusCode = 200;
                    await context.Response.CompleteAsync();
                    return;
                }
                await next.Invoke();
            });

            app.UseAuthorization();

            // Middleware to log requests and responses
            app.Use(async (context, next) =>
            {
                Console.WriteLine($"Request: {context.Request.Method} {context.Request.Path}");
                foreach (var header in context.Request.Headers)
                {
                    Console.WriteLine($"Header: {header.Key} = {header.Value}");
                }

                await next.Invoke();

                Console.WriteLine($"Response: {context.Response.StatusCode}");
                foreach (var header in context.Response.Headers)
                {
                    Console.WriteLine($"Response Header: {header.Key} = {header.Value}");
                }
            });

            app.MapControllers();

            app.Run();
        }
    }
}
