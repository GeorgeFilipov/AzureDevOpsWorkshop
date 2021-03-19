using ProjectWithMigrations.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace ProjectWithMigrations.Extensions
{
    public static class ApplicationBuilderExtensions
    {
        public static void UseAutoMigrateDatabase(this IApplicationBuilder app)
        {
            using (var scope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
            {
                var context = scope.ServiceProvider.GetService<ApplicationDbContext>();

                context.Database.Migrate();
            }
        }

        public static void UseAutoSeed(this IApplicationBuilder app)
        {
            using (var scope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
            {
                var context = scope.ServiceProvider.GetService<ApplicationDbContext>();

                var testProductId = Guid.Parse("936B20AD-A08D-49D4-A26C-6AB3E6A9E321");
                if (!context.Products.Any(p=>p.Id == testProductId))
                {
                    context.Add(new Product() { Id = Guid.Parse("936B20AD-A08D-49D4-A26C-6AB3E6A9E321"), Name = "Yes Be" });
                }
            }
        }
    }
}
