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
    public interface ICategoryService
    {
        Task<IEnumerable<Category>> GetListCategory();
        Task<IEnumerable<CategoryDto>> FullListCategory();
        Task<CudResponseDto> AddCategory(CategoryRequest request);
        Task<CudResponseDto> EditCategory(Guid id,CategoryRequest categoryRequest);
        Task<CudResponseDto> DeleteCategory(Guid id);
    }
}
