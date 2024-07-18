namespace Authenticate.API.Setup
{
    public class ClientStoreDefaultSettings
    {
        public string Secret { get; set; }
        public int AccessTokenLifetime { get; set; }
        public bool RequireConsent { get; set; }
        public string AllowedScopes { get; set; }
    }
}
