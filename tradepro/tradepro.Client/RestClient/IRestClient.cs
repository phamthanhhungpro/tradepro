using RestEase;
using tradepro.Logic.Request;

namespace tradepro.Client.RestClient
{
    public interface IRestClient
    {
        [Post("/api/auth/login")]
        Task<HttpResponseMessage> LoginAsync([Body] LoginModel login);

        [Post("/api/auth/register")]
        Task<HttpResponseMessage> RegisterAsync([Body] UserRequest user);

        [Get("/filter-role")]
        Task<HttpResponseMessage> ListRole();

        [Post("/list-user")]
        Task<HttpResponseMessage> GetListUser();

    }
}
