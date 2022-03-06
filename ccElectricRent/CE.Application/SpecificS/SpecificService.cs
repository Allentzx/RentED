using CE.Data.EF;
using CE.ViewModel.Common;
using CE.ViewModel.SpecificA;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CE.Application.SpecificS
{
    public class SpecificService : ISpecificService
    {
        private readonly CeDbContext _context;

        public SpecificService(CeDbContext context)
        {
            _context = context;
        }

        public Task<ApiResult<int>> Create(string productId, SpecificCreateRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<int> Delete(int SpecId)
        {
            throw new NotImplementedException();
        }

        public Task<ApiResult<PagedResult<SpecificViewModels>>> GetAllPaging(GetManageSpecificPagingRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<ApiResult<SpecificViewModels>> GetByID(int SpecId)
        {
            throw new NotImplementedException();
        }

        public Task<ApiResult<List<SpecificViewModels>>> GetByProductId(int ProductId)
        {
            throw new NotImplementedException();
        }

        public Task<ApiResult<bool>> Update(int SpecId, SpecificUpdateRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
