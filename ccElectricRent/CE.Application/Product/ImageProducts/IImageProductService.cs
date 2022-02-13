using CE.ViewModel.Common;
using CE.ViewModel.Products;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CE.Application.Product.ImageProducts
{
   public interface IImageProductService
    {
        Task<ApiResult<bool>> Create(ImageProductCreateRequest request);
        Task<ApiResult<bool>> Update(int imageProductId, ImageProductUpdateRequest request);
        Task<ApiResult<ImageProductViewModels>> GetByID(int imageProductId);
        Task<int> Delete(int imageProductId);
    }
}
