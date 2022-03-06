using CE.ViewModel.Common;
using CE.ViewModel.SpecificA;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CE.Application.SpecificS
{
  public interface ISpecificService
    {
        Task<ApiResult<int>> Create(string productId, SpecificCreateRequest request);

        Task<ApiResult<bool>> Update(int SpecId, SpecificUpdateRequest request);
        public Task<int> Delete(int SpecId);
        public Task<ApiResult<SpecificViewModels>> GetByID(int SpecId);
        public Task<ApiResult<PagedResult<SpecificViewModels>>> GetAllPaging(GetManageSpecificPagingRequest request);
        public Task<ApiResult<List<SpecificViewModels>>> GetByProductId(int ProductId);
    }
}
