using System;
using System.Collections.Generic;
using System.Security.Claims;

namespace ProjectAlliance.Services
{
    public interface IJwtTokenManager
    {
        string Authenticate(string UserName, int id, string Password);
        string getUserId(IEnumerable<Claim> claim);
    }
}
