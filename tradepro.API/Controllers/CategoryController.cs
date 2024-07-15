using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using tradepro.InfraModel.DataAccess;
using tradepro.Logic.DTOs;
using tradepro.Logic.Interfaces;
using tradepro.Logic.Request;

namespace tradepro.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        public CategoryController (ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet("/list-category")]
        public async Task<IEnumerable<Category>> GetListCategory()
        {
            return await _categoryService.GetListCategory();
        }

        [HttpPost("/add-category")]
        public async Task<CudResponseDto> AddCategory(CategoryRequest categoryRequest)
        {
            return await _categoryService.AddCategory(categoryRequest);
        }

        [HttpPost("/edit-category")]
        public async Task<CudResponseDto> EditCategory(Guid id,CategoryRequest categoryRequest)
        {
            return await _categoryService.EditCategory(id, categoryRequest);
        }

        [HttpPost("/delete-category")]
        public async Task<CudResponseDto> DeleteCategory(Guid id)
        {
            return await _categoryService.DeleteCategory(id);
        }

        [HttpGet("/full-list-category")]
        public async Task<IEnumerable<CategoryDto>> FullListCategory()
        {
            return await _categoryService.FullListCategory();
        }


    }
}
