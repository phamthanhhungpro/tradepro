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

        [Get("/list-category")]
        Task<HttpResponseMessage> GetListCategoryAsync();

        [Get("/full-list-category")]
        Task<HttpResponseMessage> GetFullListCategoryAsync();

        [Post("/add-category")]
        Task<HttpResponseMessage> AddCategoryAsync([Body] CategoryRequest category);

        [Post("/delete-category")]
        Task<HttpResponseMessage> DeteleCategoryAsync (Guid id);

        [Post("/edit-category")]
        Task<HttpResponseMessage> EditCategory(Guid id,[Body] CategoryRequest categoryRequest);
    }
}
