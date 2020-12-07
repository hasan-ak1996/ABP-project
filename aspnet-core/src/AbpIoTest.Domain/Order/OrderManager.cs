using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Services;
using System.Linq.Dynamic.Core;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp;

namespace AbpIoTest.Order
{
    public class OrderManager : DomainService, IOrderManager
    {
        private readonly IRepository<OrderEntity.Order,int> orderRepository;

        public OrderManager(IRepository<OrderEntity.Order,int> orderRepository)
        {
            this.orderRepository = orderRepository;
        }
        public async Task CreateOrder(OrderEntity.Order entity)
        {
            await orderRepository.InsertAsync(entity);
        }

        public async Task DeleteOrder(int id)
        {
            var order = await orderRepository.FirstOrDefaultAsync(o => o.Id == id);

            if (order == null)
            {
                throw new UserFriendlyException("No Order Found");
            }
            else
            {
                await orderRepository.DeleteAsync(order);
            }
        }

        public async Task<OrderEntity.Order> GetOrderById(int id)
        {
            return await orderRepository.FirstOrDefaultAsync(o => o.Id == id);
        }

        public async Task UpdateOrder(OrderEntity.Order entity)
        {
            await orderRepository.UpdateAsync(entity);
        }
    }
}
