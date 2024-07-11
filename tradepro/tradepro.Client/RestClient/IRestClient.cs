using RestEase;
using tradepro.Logic.DTOs;
using tradepro.Logic.Request;

namespace tradepro.Client.RestClient
{
    public interface IRestClient
    {
        [Post("/auth/login")]
        Task<LoginResponse> LoginAsync([Body] LoginModel login);
    }
}
