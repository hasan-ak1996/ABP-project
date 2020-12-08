using InterfaceOrderAppService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace AbpIoTest.Order
{
    public class OrderAppService : ApplicationService, IOrderAppService
    {
        private readonly OrderManager orderManager;
        private readonly IRepository<OrderEntity.Order, int> orderRepository;

        public OrderAppService(OrderManager orderManager, IRepository<OrderEntity.Order, int> orderRepository)
        {
            this.orderManager = orderManager;
            this.orderRepository = orderRepository;
        }
        public async Task CreateOrder(CreateOrderInputDTO input)
        {
            var OrderDateLocale = input.OrderDate.ToLocalTime();

            input.OrderDate = OrderDateLocale;

            OrderEntity.Order output = ObjectMapper.Map<CreateOrderInputDTO, OrderEntity.Order>(input);
            await orderManager.CreateOrder(output);
        }

        public async Task DeleteOrder(int id)
        {
            await orderManager.DeleteOrder(id);
        }

        public async Task<PagedResultDto<OrderDTO>> GetAllOrders(GetOrderListDto input)
        {
            
            var ordersCount = orderRepository.Count();
            List<OrderEntity.Order> orders =
                await orderRepository.WhereIf(!input.keyword.IsNullOrWhiteSpace(), o => o.Name.Contains(input.keyword)
                     || o.OrderNo.Contains(input.keyword)
                     || o.EmpolyeeName.Contains(input.keyword))
                .WhereIf(input.IsSubmit != null, o => o.IsSubmit == input.IsSubmit)
                .PageBy(input).ToListAsync();
            return new PagedResultDto<OrderDTO>
            {
                TotalCount = ordersCount,
                Items = ObjectMapper.Map<List<OrderEntity.Order>, List<OrderDTO>>(orders)
            };
        }

        public async Task<OrderDTO> GetLastOrderCreated()
        {
           
            var lasCreationTime = orderRepository.Max(o => o.CreationTime);
            var order = await orderRepository.FirstOrDefaultAsync(o => o.CreationTime == lasCreationTime);
            OrderDTO output = ObjectMapper.Map<OrderEntity.Order, OrderDTO>(order);
            return output;

        }

        public async Task<OrderDTO> GetOrderById(int id)
        {
            var order = await orderManager.GetOrderById(id);
            OrderDTO output = ObjectMapper.Map<OrderEntity.Order, OrderDTO>(order);
            return output;
        }



        public async Task UpdateOrder(int id, UpdateOrderInputDTO input)
        {
            var order = await orderManager.GetOrderById(id);
            order.Name = input.Name;
            order.OrderNo = input.OrderNo;
            order.OrderDate = input.OrderDate;
            order.IsSubmit = input.IsSubmit;
            order.EmpolyeeName = input.EmpolyeeName;
            order.TotalPrice = input.TotalPrice;

            await orderManager.UpdateOrder(order);
        }
    }
}
