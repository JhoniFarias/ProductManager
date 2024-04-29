using Microsoft.EntityFrameworkCore;
using ProductContext.Infrastructure;

namespace ProductContext.API.Extensions
{
    public static class DatabaseMigrate
    {
        public static async Task MigrateDb(this WebApplication webApplication)
        {
            using var scope = webApplication.Services.CreateScope();
            await using var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
            await dbContext.Database.MigrateAsync();
        }
    }
}
