namespace Authenticate.API.Setup
{
    public static class SettingsConfig
    {
        public static IServiceCollection AddSettingsConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<ClientStoreDefaultSettings>(configuration.GetSection("ClientStoreDefaultSettings"));
            return services;
        }
    }
}
