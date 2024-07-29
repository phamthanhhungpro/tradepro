using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tradepro.Logic.DTOs;
using tradepro.Logic.Request;

namespace tradepro.Logic.Interfaces
{
    public interface IProductStoreService
    {
        Task<CudResponseDto> AddProductStore (ProductStoreRequest request);
        Task<IEnumerable<ProdducStoreDto>> GetProducStoreByStoreId(Guid id);
    }
}
