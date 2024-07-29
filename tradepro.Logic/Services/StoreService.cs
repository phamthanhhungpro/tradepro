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
    public class StoreService : IStoreService
    {
        private readonly TradeproDbContext _dbContext;
        public StoreService(TradeproDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<CudResponseDto> CreateStore(StoreRequest request)
        {
            var store = new Store()
            {
                Id = new Guid(),
                Name = request.StoreName,
                Description = request.Description,
                Product = _dbContext.Products.Find(request.ProductId),
                CreatedAt = DateTime.UtcNow,
                User = _dbContext.Users.Find(request.UserId),
            };

            _dbContext.Stores.Add(store);
            await _dbContext.SaveChangesAsync();
            return new CudResponseDto()
            {
                Id = store.Id,
            };
            
        }

        public async Task<IEnumerable< StoreInfoDto>> GetListStore()
        {
            return await _dbContext.Stores
                .Include(x=>x.User)
                .Include(x=>x.Product)
                .Where(x=>x.IsDeleted == false)
                .Select(x=> new StoreInfoDto()
                {
                    Id =x.Id,
                    Name = x.Name,
                    Description= x.Description,
                    CreateBy = x.User.Email,
                    Product = x.Product.Name,
                }).ToListAsync();
        }
    }
}
