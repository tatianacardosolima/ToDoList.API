﻿namespace Authenticate.API.Queries
{
    public class UserQuery
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }

        public string Password { get; set; }
    }
}
