using AppSettingsAssignment.DataModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace AppSettingsAssignment.Extensions.Startup
{
    public static class ConfigureStorageExtension
    {
        public static void AddDatabaseContexts(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            if (services == null)
            {
                throw new ArgumentNullException(nameof(Services));
            }

            services.AddDbContextPool<StudentsDBContext>(options =>
            {
                options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
                options.UseSqlServer(
                        configuration.GetConnectionString("DBContext"),
                        sqlServerOptions => sqlServerOptions.CommandTimeout(120));
            });
        }
    }
}
