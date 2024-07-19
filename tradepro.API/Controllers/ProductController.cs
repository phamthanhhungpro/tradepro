using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using tradepro.Logic.DTOs;
using tradepro.Logic.Interfaces;
using tradepro.Logic.Request;

namespace tradepro.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpPost("/add-product")]
        public async Task<CudResponseDto> AddProduct(ProductRequest productRequest)
        {
            return await _productService.AddProduct(productRequest);
        }

        [HttpGet("/list-product")]
        public async Task<IEnumerable<ProductDto>> GetListProduct ()
        {
            return await _productService.GetListProduct();
        }

        [HttpPost("/edit-product")]
        public async Task<CudResponseDto> EditProduct(Guid id, ProductRequest productRequest)
        {
            return await _productService.EditProduct(id, productRequest);
        }

        [HttpPost("/delete-product")]
        public async Task<CudResponseDto> DeleteProduct(Guid id)
        {
            return await _productService.DeleteProduct(id);
        }
    }
}
