using RestEase;
using tradepro.Logic.Request;

namespace tradepro.Client.RestClient
{
    public interface IRestClient
    {
        [Post("/api/auth/login")]
        Task<HttpResponseMessage> LoginAsync([Body] LoginModel login);
    }
}
