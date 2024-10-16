using Application.Models;

namespace Application.Interfaces
{
    public interface IAuthService
    {
        string Authenticate(CredentialsForAuthenticate credentials);

    }
}