namespace AppSettingsAssignment.Extensions.Startup
{
    public static class ConfigureAutoMapperStartupExtension
    {
        public static void AddMapper(this IServiceCollection services)
        {
            if (services == null) 
            { 
                throw new ArgumentNullException(nameof(services));
            }

            services.AddAutoMapper(
                ApiMappingProfilesResolver.GetTypeToDiscoverAssembly(),
                DomainMappingProfilesResolver.GetTypeToDiscoverAssembly());
        }
    }
}
