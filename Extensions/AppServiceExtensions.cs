using iTestApi.Entities.Core;
using iTestApi.Services;
using Microsoft.EntityFrameworkCore;

namespace iTestApi.Extensions;

public static class AppServiceExtensions
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration config)
    {
        var connectionString = config.GetConnectionString("DefaultConnection");
        
        services.AddDbContext<DataContext>(x => x.UseMySql(
            connectionString, 
            ServerVersion.AutoDetect(connectionString)
        ));

        services.AddScoped<TokenService>();
        services.AddScoped<AuthService>();
        services.AddScoped<UserService>();
        services.AddScoped<QuestionService>();
        services.AddScoped<FavoriteService>();

        return services;
    }

}