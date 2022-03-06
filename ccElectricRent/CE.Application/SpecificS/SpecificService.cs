using CE.Application.Ultilities;
using CE.Data.EF;
using CE.Data.Entity;
using CE.ViewModel.Common;
using CE.ViewModel.SpecificA;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public async Task<ApiResult<int>> Create(int productId, SpecificCreateRequest request)
        {
            Dictionary<string, List<string>> errors = new Dictionary<string, List<string>>();
            bool checkProductKey = false;
            var specific = await _context.Specifics.FindAsync(request.SpecId);
            var checkText = new string(request.ProductKey.Where(c => !Char.IsWhiteSpace(c)).ToArray());
            if (specific != null)
            {
                if (checkText.All(char.IsDigit))
                {
                    UltilitiesService.AddOrUpdateError(errors, "productKey", "Productkey can not be digits only");
                   checkProductKey = true;
                }
                if (!specific.ProductKey.Equals(request.ProductKey))
                {
                    var checkName = _context.Specifics.Where(x => x.ProductKey.Equals(request.ProductKey)).Select(x => new Specific()).FirstOrDefault();
                    if (checkName != null)
                    {
                        if (checkProductKey == false)
                        {
                            UltilitiesService.AddOrUpdateError(errors, "ProductKey", "This Key already exists");
                        }
                    }
                }
                if (errors.Count() > 0)
                {
                    return new ApiErrorResult<int>(errors);
                }
                specific.ProductKey = request.ProductKey;
                specific.Value = request.Value;
                _context.Specifics.Update(specific);
                var result = await _context.SaveChangesAsync();
                if (result == 0)
                {
                    return new ApiErrorResult<int>("Update Specific failed");
                }
            }
            else
            {
                if (checkText.All(char.IsDigit))
                {
                    UltilitiesService.AddOrUpdateError(errors, "ProductKey", "ProductKey can not be digits only");
                    checkProductKey = true;
                }
                var checkName = _context.Specifics.Where(x => x.ProductKey.Equals(request.ProductKey))
                    .Select(x => new Specific()).FirstOrDefault();
                if (checkName != null)
                {
                    if (checkProductKey == false)
                    {
                        UltilitiesService.AddOrUpdateError(errors, "ProductKey", "This Key already exists");
                    }
                }
                if (errors.Count() > 0)
                {
                    return new ApiErrorResult<int>(errors);
                }
                specific = new Specific()
                {
                    ProductKey = request.ProductKey,
                    Value = request.Value,
                    ProductId = productId,
                };
                _context.Specifics.Add(specific);
                var result = await _context.SaveChangesAsync();
                if (result == 0)
                {
                    return new ApiErrorResult<int>("Create project failed");
                }
            }
            return new ApiSuccessResult<int>(specific.SpecId);
        }

        public async Task<ApiResult<bool>> Delete(int specId)
        {
            var specific = await _context.Specifics.FindAsync(specId);
            if (specific == null) return new ApiErrorResult<bool>("Specific does not exist");
            _context.Specifics.Remove(specific);
            var result = await _context.SaveChangesAsync();
            if (result == 0)
            {
                return new ApiErrorResult<bool>("Delete Specific failed");
            }
            return new ApiSuccessResult<bool>();
        }

        public Task<ApiResult<PagedResult<SpecificViewModels>>> GetAllPaging(GetManageSpecificPagingRequest request)
        {
            throw new NotImplementedException();
        }

        public async Task<ApiResult<SpecificViewModels>> GetByID(int specId)
        {
            var query = from s in _context.Specifics
                        join p in _context.Products on s.ProductId equals p.ProductId
                        select new { s, p };
            var sVm = await query.Where(x => x.s.SpecId.Equals(specId)).Select(x => new SpecificViewModels()
            {
                ProductId = x.p.ProductId,
                ProductKey= x.s.ProductKey,
                SpecId = x.s.SpecId,
                Value = x.s.Value,
                
            }).FirstOrDefaultAsync();
            if (sVm == null) return new ApiErrorResult<SpecificViewModels>("Specific does not exist");
            return new ApiSuccessResult<SpecificViewModels>(sVm);
        }

        public Task<ApiResult<ListSpecificViewModel>> GetSpecificByProductId(int productId, GetManageSpecificPagingRequest request)
        {
            throw new NotImplementedException();
        }

        public async Task<ApiResult<bool>> Update(int specId, SpecificUpdateRequest request)
        {
            Dictionary<string, List<string>> errors = new Dictionary<string, List<string>>();
            var specific = await _context.Specifics.FindAsync(specId);
            if (specific == null) return new ApiErrorResult<bool>("Specific does not exist");

            if (request.ProductKey.All(char.IsDigit))
            {
                UltilitiesService.AddOrUpdateError(errors, "ProductKey", "ProductKey can not be digits only");
            }
            if (errors.Count() > 0)
            {
                return new ApiErrorResult<bool>(errors);
            }
            specific.ProductId = request.ProductId;
            specific.ProductKey = request.ProductKey;
            specific.Value = request.Value;
            _context.Specifics.Update(specific);
            var result = await _context.SaveChangesAsync();
            if (result == 0)
            {
                return new ApiErrorResult<bool>("Update Specific failed");
            }
            return new ApiSuccessResult<bool>();
        }
    }
}
