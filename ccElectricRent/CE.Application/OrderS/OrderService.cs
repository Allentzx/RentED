using CE.Data.EF;
using CE.Data.Entity;
using CE.ViewModel.Common;
using CE.ViewModel.Order;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CE.Application.OrderS
{
    public class OrderService : IOrderService
    {
        private readonly CeDbContext _context;
        public OrderService(CeDbContext context)
        {
            _context = context;
        }
        public async Task<ApiResult<bool>> Create(OrderCreateRequest request)
        {
            Dictionary<string, List<string>> errors = new Dictionary<string, List<string>>();
            if (errors.Count() > 0)
            {
                return new ApiErrorResult<bool>(errors);
            }
            var ord = new Order()
            {
                UserId = request.UserId,
                VoucherId = request.VoucherId,
                CreateDate = request.CreateDate,
                Status = request.Status
            };
            _context.Orders.Add(ord);

            var result = await _context.SaveChangesAsync();
            if (result == 0)
            {
                return new ApiErrorResult<bool>("Create Order failed");
            }
            return new ApiSuccessResult<bool>();
        }
    }
}

