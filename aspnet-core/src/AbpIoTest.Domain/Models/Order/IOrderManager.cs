using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Services;

namespace AbpIoTest.Order
{
    public interface IOrderManager : IDomainService
    {
        Task<OrderEntity.Order> GetOrderById(int id);
        Task CreateOrder(OrderEntity.Order entity);
        Task DeleteOrder(int id);
        Task UpdateOrder(OrderEntity.Order entity);
    }
}
