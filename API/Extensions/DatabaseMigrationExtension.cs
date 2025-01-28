using Microsoft.EntityFrameworkCore;

public static class DatabaseMigrationExtension {
    public async static Task<WebApplication> MigrateDatabase(this WebApplication app) 
    {
        using (var scope = app.Services.CreateScope()) 
        {
            var contextService = scope.ServiceProvider.GetService<SkinetContext>();
            var loggerFactory = scope.ServiceProvider.GetService<ILoggerFactory>();
            try {
                await contextService.Database.MigrateAsync();
                StoreContextSeed.SeedStoreContext(contextService, loggerFactory);

            } catch (Exception ex){
                var logger = loggerFactory.CreateLogger<Program>();
                logger.LogError($"An Exception occure while Migration :{ex.Message}");
            }
        }
        return app;
    }
}