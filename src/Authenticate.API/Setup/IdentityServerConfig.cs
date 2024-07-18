using Authenticate.API.IdentityCustom;
using Authenticate.API.IdentityCustom.Stores;
using Authenticate.API.Queries;
using Authenticate.API.Repositories;
using IdentityServer4.Stores;
using Microsoft.AspNetCore.Identity;
using Microsoft.Data.SqlClient;
using Microsoft.IdentityModel.Tokens;
using System.Data;

namespace Authenticate.API.Setup
{
    public static class IdentityServerConfig
    {
        public static IServiceCollection AddIdentityServerConfiguration(this IServiceCollection services,
            IConfiguration configuration)
        {

            services.AddScoped<IDbConnection, SqlConnection>((connection) => new SqlConnection(configuration["ConnectionStrings:SqlServer"]));

            services.AddScoped<IUserRepository, UserRepository>();

            //services.AddIdentity<UserQuery, IdentityRole<Guid>>();
                      

            // Configure identity server with in-memory stores, keys, clients and scopes
            var builder = services.AddIdentityServer()
                .AddInMemoryApiResources(Config.ApiResources)
                .AddClientStore<ClientStore>()
                .AddInMemoryApiScopes(Config.ApiScopes)
                .AddResourceOwnerValidator<ResourceOwnerPasswordValidatorCustom>();
            
            builder.AddDeveloperSigningCredential();

            #region JWT

            // accepts any access token issued by identity server
            services.AddAuthentication("Bearer")
                .AddJwtBearer("Bearer", options =>
                {
                    options.Authority = configuration["AuthorityUrl"];
                    options.SaveToken = true;
                    options.RequireHttpsMetadata = false; // TODO: Verificar necessidade disso no servidor
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateAudience = false
                    };
                });

            // adds an authorization policy to make sure the token is for scope 'onpoint.api'
            services.AddAuthorization(options =>
            {
                options.AddPolicy("ApiScope", policy =>
                {
                    policy.RequireAuthenticatedUser();
                    policy.RequireClaim("scope", configuration["AllowedScopes"]);
                });
            });

            #endregion

            return services;
        }

        public static IApplicationBuilder UseIdentityServerConfiguration(this IApplicationBuilder app)
        {
            app.UseIdentityServer();

            app.UseAuthentication();
            app.UseAuthorization();

            return app;
        }
    }
}
