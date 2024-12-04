using Context;
using DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

public class Program
{
    public static void Main(string[] args)
    {
        CreateHostBuilder(args).Build().Run();
    }

    public static IHostBuilder CreateHostBuilder(string[] args) =>
        Host.CreateDefaultBuilder(args)
            .ConfigureWebHostDefaults(webBuilder =>
            {
                var builder = WebApplication.CreateBuilder(args);

                webBuilder.ConfigureServices(services =>
                {
                    var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

                    services.AddDbContext<ApiDbContext>(x => x.UseSqlServer(connectionString));

                    // Add CORS policy to allow React app to connect
                    services.AddCors(options =>
                    {
                        options.AddPolicy("AllowReactApp",
                            builder =>
                            {
                                builder.WithOrigins("http://localhost:3001") // React app's URL
                                       .AllowAnyHeader()
                                       .AllowAnyMethod();
                            });
                    });

                    // Add controllers and Swagger
                    services.AddControllers();
                    services.AddSwaggerGen(c =>
                    {
                        c.SwaggerDoc("v1", new OpenApiInfo { Title = "Your API Title", Version = "v1" });
                    });
                    ConfigureUtils.SetDI(services);

                });

                webBuilder.Configure(app =>
                {
                    // Enable CORS
                    app.UseCors("AllowReactApp");

                    // Enable Swagger in development mode
                    app.UseSwagger();
                    app.UseSwaggerUI(c =>
                    {
                        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Your API Title v1");
                        c.RoutePrefix = "swagger"; // Makes it available at /swagger/index.html
                    });

                    // Configure routing
                    app.UseRouting();
                    app.UseAuthorization();

                    app.UseEndpoints(endpoints =>
                    {
                        endpoints.MapControllers();
                    });
                });
            });
}
