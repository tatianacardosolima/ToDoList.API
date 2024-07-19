using Authenticate.API.Repositories;
using Common.Password;
using Duende.IdentityServer.Models;
using Duende.IdentityServer.Validation;
using System.Security.Claims;

namespace Authenticate.API.IdentityCustom
{
    public class ResourceOwnerPasswordValidatorCustom : IResourceOwnerPasswordValidator
    {
        private IUserRepository _repository;

        public ResourceOwnerPasswordValidatorCustom(IUserRepository repository)
        {
            _repository = repository;
        }
        public async Task ValidateAsync(ResourceOwnerPasswordValidationContext context)
        {
            var passwordService = new PasswordService();

            var user = await _repository.GetByEmailAsync(context.UserName);

            Dictionary<string, object> customResponse = new Dictionary<string, object>()
            {
                { "issuer", "Tatiana Lima - To Do List" }
            };

            if (user == null)
            {
                context.Result = new GrantValidationResult(
                   TokenRequestErrors.InvalidGrant,
                   "Usuário ou Senha inválidos.",
                   customResponse);
                
            }
            else
            {
                
                var passwordOk = passwordService.VerifyPassword(user.Password, context.UserName, context.Password);
                if (passwordOk)
                {
                    context.Result = new GrantValidationResult(
                       subject: user.Id.ToString(),
                       authenticationMethod: "pwd",
                       claims: new Claim[]
                       {

                        new Claim("sub", user.Id.ToString()),
                        new Claim("name", user.Name),
                        new Claim("email", user.Email),

                       });
                }
                else
                {
                    context.Result = new GrantValidationResult(
                       TokenRequestErrors.InvalidGrant,
                       "Usuário ou Senha inválidos.",
                       customResponse);
                }
            }
        }
    }
}
