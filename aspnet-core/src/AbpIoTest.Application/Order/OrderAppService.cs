using InterfaceOrderAppService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace AbpIoTest.Order
{
    public class OrderAppService : ApplicationService, IOrderAppService
    {
        private readonly OrderManager orderManager;

        public OrderAppService(OrderManager orderManager)
        {
            this.orderManager = orderManager;
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

        public async Task<OrderDTO> GetOrderById(int id)
        {
            var order = await orderManager.GetOrderById(id);
            OrderDTO output = ObjectMapper.Map<OrderEntity.Order, OrderDTO>(order);
            return output;
        }

        public async Task UpdateOrder(UpdateOrderInputDTO input)
        {
            OrderEntity.Order output = ObjectMapper.Map<UpdateOrderInputDTO, OrderEntity.Order>(input);
            await orderManager.UpdateOrder(output);
        }
    }
}
