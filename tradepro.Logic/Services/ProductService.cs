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
    public class ProductService : IProductService
    {
        private readonly TradeproDbContext _context;
        public ProductService(TradeproDbContext context)
        {
            _context = context;
        }
        public async Task<CudResponseDto> AddProduct(ProductRequest productRequest)
        {
            var product = new Product()
            {
                Name = productRequest.ProductName,
                Category = _context.Categories.Find(productRequest.CategoryId),
                CreatedAt = DateTime.UtcNow
            };
            _context.Products.Add(product);
            await _context.SaveChangesAsync();
            return new CudResponseDto()
            {
                Id = product.Id,
            };
        }

        public  async Task<CudResponseDto> DeleteProduct(Guid id)
        {
            var product = await _context.Products.FindAsync(id);
            if(product == null) 
            {
                throw new Exception($"product not found");
            }
            product.IsDeleted = true;
            product.DeletedAt = DateTime.UtcNow;
            await _context.SaveChangesAsync();
            return new CudResponseDto
            {
                Id = product.Id,
            };
        }

        public async Task<CudResponseDto> EditProduct(Guid id, ProductRequest productRequest)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null)
            {
                throw new Exception($"product not found");
            }
            product.Name = productRequest.ProductName;
            product.Category = _context.Categories.Find( productRequest.CategoryId);
            product.UpdatedAt   = DateTime.UtcNow;
            await  _context.SaveChangesAsync( );
            return new CudResponseDto
            {
                Id = product.Id,
            };
        }

        public async Task<IEnumerable<ProductDto>> GetListProduct()
        {
            return await _context.Products.Include(x=>x.Category).Where(x=>x.IsDeleted == false).Select(x=>new ProductDto()
            {
                Id=x.Id,
                Name = x.Name,
                Category = x.Category,
            }).ToListAsync();
        }
    }
}
