using Authenticate.API.Repositories;
using Duende.IdentityServer.Extensions;
using Duende.IdentityServer.Models;
using Duende.IdentityServer.Services;
using System.Security.Claims;

namespace Authenticate.API.IdentityCustom.Services
{
    public class ProfileService : IProfileService
    {
        private readonly IUserRepository _repository;
        #region Scope

        public ProfileService(IUserRepository repository)
        {
            _repository = repository;
        }

        #endregion

        #region IProfileService (IdentityServer4 interface)

        public async Task GetProfileDataAsync(ProfileDataRequestContext context)
        {
            var sub = context.Subject.GetSubjectId();
            var user = await _repository.GetByIdAsync(Guid.Parse(sub));
            if (user == null)
                throw new NullReferenceException(nameof(user));

            var claims = new List<Claim>
            {
                new Claim("sub", user.Id.ToString()),
                new Claim("name", user.Name),
                new Claim("email", user.Email)                
            };
            

            context.IssuedClaims = claims;
        }

        public async Task IsActiveAsync(IsActiveContext context)
        {
            var sub = context.Subject.GetSubjectId();
            var user = await _repository.GetByIdAsync(Guid.Parse(sub));
            context.IsActive = user != null;
        }

      
        #endregion
    }
}
