using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Password
{
    public class PasswordService
    {
        private readonly IPasswordHasher<PasswordUser> _passwordHasher;

        public PasswordService()
        {
            _passwordHasher = new PasswordHasher<PasswordUser>();
        }

        public string HashPassword(string email,string password)
        {
            var user = new PasswordUser { Email = email};             
            return _passwordHasher.HashPassword(user, password);
        }

        public bool VerifyPassword(string hashedPassword, string email, string password)
        {
            var user = new PasswordUser { Email = email};
            var result = _passwordHasher.VerifyHashedPassword(user, hashedPassword, password);
            return result == PasswordVerificationResult.Success;
        }
        protected class PasswordUser
        {
            public string Email { get; set; }
            
        }
    }

    
}
