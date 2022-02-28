using CE.ViewModel.Catagory;
using CE.ViewModel.Common;
using CE.ViewModel.Products;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CE.Application.Product
{
   public interface IProductService
    {
        Task<int> Create(ProductCreateRequest request);
        Task<bool> Update(ProductUpdateRequest request);
        Task<int> Delete(int productId);
        Task<ApiResult<int>> ChangeStatus(int productId);
        Task<ApiResult<ProductViewModels>> GetByID(int productId);
        Task<PagedResult<ProductViewModels>> GetAllPaging(GetManageProductPagingRequest request);
        Task<ApiResult<List<CategoryViewModels>>> GetCategory();
        Task<ApiResult<List<ProductViewModels>>> GetProductByCategory(int categoryId);



    }
}
