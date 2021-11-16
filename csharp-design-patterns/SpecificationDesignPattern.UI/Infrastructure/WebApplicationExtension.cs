namespace SpecificationDesignPattern.UI.Infrastructure;

public static class WebApplicationExtension
{
    public static Task RunMigrationAsync(this WebApplication webApplication)
    {
        var dbFactory = webApplication.Services
            .GetRequiredService<IDbContextFactory<SpecPatternReadDbContext>>();

        var dbContext = dbFactory.CreateDbContext();
        return dbContext.Database.MigrateAsync();
    }
}
