using CE.Data.EF;
using CE.Data.Entity;
using CE.ViewModel.Common;
using CE.ViewModel.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CE.Application.Product.ImageProducts
{
    public class ImageProductService : IImageProductService
    {
        private readonly CeDbContext _context;

        public ImageProductService(CeDbContext context)
        {
            _context = context;
        }

        public async Task<ApiResult<bool>> Create(ImageProductCreateRequest request)
        {
            var checkName = _context.ImageProducts.Where(x => x.Url.Equals(request.Url))
              .Select(x => new ImageProduct()).FirstOrDefault();
            if (checkName != null)
            {
                return new ApiErrorResult<bool>("This url name already exist");
            }
            var imp = new ImageProduct
            {
                Url = request.Url,
            };
            _context.ImageProducts.Add(imp);
            var result = await _context.SaveChangesAsync();
            if (result == 0)
            {
                return new ApiErrorResult<bool>("Create image failed");
            }
            return new ApiSuccessResult<bool>();
        }


        public async Task<ApiResult<ImageProductViewModels>> GetByID(int imageId)
        {
            var img = await _context.ImageProducts.FindAsync(imageId);
            if (img == null) return new ApiErrorResult<ImageProductViewModels>("image does not exist");

            var imgViewModel = new ImageProductViewModels()
            {
                ImageId = imageId,
                Url = img.Url,
                PrlItemId =img.PrlItemId
            };

            return new ApiSuccessResult<ImageProductViewModels>(imgViewModel);
        }

       

        public async Task<ApiResult<bool>> Update(int imageProductId, ImageProductUpdateRequest request)
        {

            var img = await _context.ImageProducts.FindAsync(imageProductId);
            if (img == null) new ApiErrorResult<bool>("url does not exist");
            if (!img.Url.Equals(request.Url))
            {
                var checkName = _context.ImageProducts.Where(x => x.Url.Equals(request.Url))
                 .Select(x => new Voucher()).FirstOrDefault();
                if (checkName != null)
                {
                    return new ApiErrorResult<bool>("This url already exist");
                }
                else
                {
                    img.Url = request.Url;
                }
            }
            _context.ImageProducts.Update(img);
            var result = await _context.SaveChangesAsync();
            if (result == 0)
            {
                return new ApiErrorResult<bool>("Update imge failed");
            }
            return new ApiSuccessResult<bool>();
        }

        public async Task<int> Delete(int voucherId)
        {
            var voucher = await _context.Vouchers.FindAsync(voucherId);
            if (voucher == null)
                throw new Exception($"Cannot find an image with id {voucherId}");
            _context.Vouchers.Remove(voucher);
            return await _context.SaveChangesAsync();
        }
    }
}