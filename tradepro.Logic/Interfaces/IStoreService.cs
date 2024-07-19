using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tradepro.Logic.DTOs;
using tradepro.Logic.Request;

namespace tradepro.Logic.Interfaces
{
    public interface IStoreService
    {
        Task<CudResponseDto> CreateStore(StoreRequest request);
        Task< IEnumerable<StoreInfoDto>> GetListStore(); 

    }
}
