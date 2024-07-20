using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tradepro.InfraModel.DataAccess;
using tradepro.Logic.DTOs;
using tradepro.Logic.Request;

namespace tradepro.Logic.Interfaces
{
    public interface IProductService
    {
        Task<CudResponseDto> AddProduct(ProductRequest productRequest);
        Task<IEnumerable<ProductDto>> GetListProduct();
        Task<CudResponseDto> EditProduct(Guid id,ProductRequest productRequest);
        Task<CudResponseDto> DeleteProduct(Guid id);

    }
}
