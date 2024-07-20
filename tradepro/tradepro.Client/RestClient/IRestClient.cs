using RestEase;
using tradepro.Logic.DTOs;
using tradepro.Logic.Request;
using tradepro.InfraModel.DataAccess;
namespace tradepro.Client.RestClient
{
    public interface IRestClient
    {
        [Post("/api/auth/login")]
        Task<HttpResponseMessage> LoginAsync([Body] LoginModel login);

        [Get("/api/auth/manage/info")]
        Task<UserInfoDto> GetUserInfoAsync();

        [Post("/api/auth/register")]
        Task<HttpResponseMessage> RegisterAsync([Body] UserRequest user);

        [Get("/filter-role")]
        Task<HttpResponseMessage> ListRole();

        [Post("/list-user")]
        Task<HttpResponseMessage> GetListUser();

        [Get("/list-category")]
        Task<List<Category>> GetListCategoryAsync();

        [Get("/full-list-category")]
        Task<HttpResponseMessage> GetFullListCategoryAsync();


        // category
        [Post("/add-category")]
        Task<HttpResponseMessage> AddCategoryAsync([Body] CategoryRequest category);

        [Post("/delete-category")]
        Task<HttpResponseMessage> DeteleCategoryAsync (Guid id);

        [Post("/edit-category")]
        Task<HttpResponseMessage> EditCategory(Guid id,[Body] CategoryRequest categoryRequest);


        // product
        [Get("/list-product")]
        Task<List<ProductDto>> GetListProductAsync();

        [Post("/add-product")]
        Task<CudResponseDto> AddProductAsync([Body]ProductRequest product);

        [Post("/edit-product")]
        Task<CudResponseDto> UpdateProduct (Guid id,[Body] ProductRequest product);

        [Post("/delete-product")]
        Task<CudResponseDto> DeleteProduct (Guid id);

    }
}
