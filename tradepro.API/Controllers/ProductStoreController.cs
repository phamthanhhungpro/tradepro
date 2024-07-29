using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using tradepro.Logic.DTOs;
using tradepro.Logic.Interfaces;

namespace tradepro.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductStoreController : ControllerBase
    {
        private readonly IProductStoreService _productStoreService;
        public ProductStoreController(IProductStoreService productStoreService)
        {
            _productStoreService = productStoreService;
        }

        [HttpGet("/list-productstore")]
        public async Task<IEnumerable<ProdducStoreDto>> GetListProductStore(Guid id) {
        
            return await _productStoreService.GetProducStoreByStoreId(id);
        }
    }
}
