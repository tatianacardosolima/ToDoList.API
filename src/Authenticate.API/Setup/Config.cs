using IdentityServer4.Models;

namespace Authenticate.API.Setup
{
    public class Config
    {
        public static IEnumerable<IdentityResource> GetIdentityResources()
        {
            return new IdentityResource[]
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile(),
            };
        }

        
        
        public static IEnumerable<ApiScope> ApiScopes =>
            new List<ApiScope>
            {
                new ApiScope("todolist.api", "APIs ToDo List")
            };

        public static IEnumerable<ApiResource> ApiResources =>
            new List<ApiResource>
            {
                new ApiResource( "todolist.api", "Aplicativos e Sistemas do projeto to do list")
                {
                    Scopes= new[]
                    {
                        "todolist.api"
                    }
                    
                }
            };
    }
}
