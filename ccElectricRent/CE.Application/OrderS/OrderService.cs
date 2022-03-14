using CE.Data.EF;
using CE.Data.Entity;
using CE.ViewModel.Common;
using CE.ViewModel.Order;
using Microsoft.EntityFrameworkCore;
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
                TotalPrice = request.TotalPrice,
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

        public async Task<ApiResult<PagedResult<OrderViewModels>>> GetAllPaging(GetManageOrderPagingRequest1 request)
        {
            var query = from o in _context.Orders
                        join u in _context.AppUsers on o.UserId equals u.Id
                        join v in _context.Vouchers on o.VoucherId equals v.VoucherId
                        select new { u, v,o };
            int totalRow = await query.CountAsync();
            var data = await query.OrderBy(x => x.o.OrderId).Skip((request.PageIndex - 1) * request.PageSize)
                .Take(request.PageSize).Select(x => new OrderViewModels()
                {
                    OrderId = x.o.OrderId,
                    UserId = x.u.Id,
                    VoucherId = x.v.VoucherId,
                    TotalPrice = x.o.TotalPrice,
                    CreateDate = x.o.CreateDate,
                    Status = x.o.Status
                }).ToListAsync();
            var pagedResult = new PagedResult<OrderViewModels>()
            {
                TotalRecords = totalRow,
                PageIndex = request.PageIndex,
                PageSize = request.PageSize,
                Items = data
            };

            return new ApiSuccessResult<PagedResult<OrderViewModels>>(pagedResult);
        }
    }
}

