using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using tradepro.Logic.DTOs;
using tradepro.Logic.Interfaces;
using tradepro.Logic.Request;

namespace tradepro.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StoreController : ControllerBase
    {
        private readonly IStoreService _storeService;
        public StoreController(IStoreService storeService)
        {
            _storeService = storeService;
        }
        [HttpPost("/add-store")]
        public async Task<CudResponseDto> CreateStore(StoreRequest storeRequest)
        {
            return await _storeService.CreateStore(storeRequest);
        }

        [HttpGet("/list-store")]
        public async Task<IEnumerable<StoreInfoDto>> GetListStore()
        {
            return await _storeService.GetListStore();
        }
    }
}
