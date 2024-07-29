using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tradepro.InfraModel.DataAccess;
using tradepro.Logic.DTOs;
using tradepro.Logic.Interfaces;
using tradepro.Logic.Request;

namespace tradepro.Logic.Services
{
    public class ProductStoreService : IProductStoreService
    {
        private readonly TradeproDbContext _dbContext;
        public ProductStoreService(TradeproDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Task<CudResponseDto> AddProductStore(ProductStoreRequest request)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<ProdducStoreDto>> GetProducStoreByStoreId(Guid id)
        {
            return await _dbContext.ProductStores.Where(x=>x.Store.Id == id).Include(x=>x.Store)
                .Select(x=> new ProdducStoreDto()
                {
                    ProductStoreName = x.Name,
                    Quantity = x.quantity,
                    Price = x.price,
                    StoreName = x.Store.Name,
                }).ToListAsync();
        }
    }
}
