using Microsoft.EntityFrameworkCore;

namespace iTestApi.Extensions;

public static class MigrateDatabaseExtension
{
    public static WebApplication MigrateDatabase<T>(this WebApplication webApp) where T : DbContext
    {
        using var scope = webApp.Services.CreateScope();
        var services = scope.ServiceProvider;
        try
        {
            var db = services.GetRequiredService<T>();
            db.Database.Migrate();
                
            Console.WriteLine("I just migrated your database. Gimme some $$. /n");
        }
        catch (Exception ex)
        {
            var logger = services.GetRequiredService<ILogger<Program>>();
            logger.LogError(ex, "An error occurred while migrating the database.");
        }
        return webApp;
    }
}