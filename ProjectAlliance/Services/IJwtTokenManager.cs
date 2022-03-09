using System;
namespace ProjectAlliance.Services
{
    public interface IJwtTokenManager
    {
        string Authenticate(string UserName, string Password);
    }
}
