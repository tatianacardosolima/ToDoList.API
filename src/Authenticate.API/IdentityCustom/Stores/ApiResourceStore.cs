using IdentityServer4.Models;
using IdentityServer4.Stores;

namespace Authenticate.API.IdentityCustom.Stores
{
    public class ApiResourceStore : IResourceStore
    {
        private static IEnumerable<ApiResource> ApiResources =>
            new List<ApiResource>
            {
                new ApiResource("apps.client", "Aplicativos e Sistemas do projeto TodoList")
                {
                    Scopes = new[]
                    {
                        "todolist.api"
                    },
                    ApiSecrets = new List<Secret>
                    {
                        new Secret("super-secret".Sha256()) // This wasn't required when attaching a .net core api
                    }
                }
            };

        public Task<IEnumerable<ApiResource>> FindApiResourcesByNameAsync(IEnumerable<string> apiResourceNames)
        {
            var result = ApiResources.Where(x => apiResourceNames.Contains(x.Name));
            return Task.FromResult(result);
        }

        public Task<IEnumerable<ApiResource>> FindApiResourcesByScopeNameAsync(IEnumerable<string> scopeNames)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ApiScope>> FindApiScopesByNameAsync(IEnumerable<string> scopeNames)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<IdentityResource>> FindIdentityResourcesByScopeNameAsync(IEnumerable<string> scopeNames)
        {
            throw new NotImplementedException();
        }

        public Task<Resources> GetAllResourcesAsync()
        {
            throw new NotImplementedException();
        }
    }
}
