using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using tradepro.InfraModel.DataAccess;
using tradepro.Logic.DTOs;
using tradepro.Logic.Interfaces;
using tradepro.Logic.Request;

namespace tradepro.Logic.Services
{
    public class CategoryService : ICategoryService
    {

        private readonly TradeproDbContext _dbContext;
        public CategoryService(TradeproDbContext    dbContext) 
        {
            _dbContext = dbContext; 
        }
        public async Task<CudResponseDto> AddCategory(CategoryRequest request)
        {
            var category = new Category()
            {
                CategoryName = request.CategoryName,
                CreatedAt = DateTime.UtcNow,
            };
             _dbContext.Categories.Add(category);
            await _dbContext.SaveChangesAsync();
            return new CudResponseDto()
            {
                Id = category.Id,
            };
        }

        public async Task<CudResponseDto> DeleteCategory(Guid id)
        {
            var item =await _dbContext.Categories.FindAsync(id); 
            if (item == null) {
                throw new Exception("not found");
            }
            item.IsDeleted = true;
            item.DeletedAt = DateTime.UtcNow;
            await _dbContext.SaveChangesAsync();
            return new CudResponseDto()
            {
                Id = item.Id,
            };
        }

        public async Task<CudResponseDto> EditCategory(Guid id, CategoryRequest categoryRequest)
        {
            var item = await _dbContext.Categories.FindAsync(id);
            if (item == null)
            {
                throw new Exception("not found");
            }
            item.CategoryName = categoryRequest.CategoryName;   
            item.UpdatedAt = DateTime.UtcNow;
            await _dbContext.SaveChangesAsync();
            return new CudResponseDto()
            {
                Id = item.Id,
            };

        }

        public async Task<IEnumerable<CategoryDto>> FullListCategory()
        {
            return await _dbContext.Categories.Where(x => x.IsDeleted == false).Select(x=> new CategoryDto()
            {
                Id=x.Id,
                Name = x.CategoryName,
            }).ToListAsync();
        }

        public async Task<IEnumerable<Category>> GetListCategory()
        {
            return await _dbContext.Categories.Where(x=>x.IsDeleted == false).ToListAsync();
        }
    }
}
