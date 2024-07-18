using Authenticate.API.Setup;
using IdentityServer4.Models;
using IdentityServer4.Stores;
using IdentityServer4;
using Microsoft.Extensions.Options;
using IdentityModel;

namespace Authenticate.API.IdentityCustom.Stores
{
    public class ClientStore : IClientStore
    {
        #region Scope
        private readonly ClientStoreDefaultSettings _clientStoreSettings;

        public ClientStore(IOptions<ClientStoreDefaultSettings> clientStoreSettings)
        {
            _clientStoreSettings = clientStoreSettings.Value;
        }
        #endregion

        #region IClientStore
        public Task<Client> FindClientByIdAsync(string clientId)
        {
            return Task.FromResult(new Client
            {
                ClientId = _clientStoreSettings.AllowedScopes,
                ClientName = "Plataforma To DO List",

                // No interactive user, use the clientid/secret for authentication
                AllowedGrantTypes = GrantTypes.ResourceOwnerPasswordAndClientCredentials,
                ClientSecrets =
                {
                    new Secret(_clientStoreSettings.Secret.ToSha256())
                },
                AccessTokenLifetime = _clientStoreSettings.AccessTokenLifetime, //três dias
                RequireConsent = _clientStoreSettings.RequireConsent,
                AllowedScopes =
                {
                    _clientStoreSettings.AllowedScopes,
                    IdentityServerConstants.StandardScopes.OfflineAccess
                },
                

                AllowOfflineAccess = true,
                SlidingRefreshTokenLifetime = _clientStoreSettings.AccessTokenLifetime,
                RefreshTokenExpiration = TokenExpiration.Sliding,
                RefreshTokenUsage = TokenUsage.ReUse
            });
        }
        #endregion
    }
}
