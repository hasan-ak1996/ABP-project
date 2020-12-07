using AbpIoTest.Order;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace InterfaceOrderAppService
{
    public interface IOrderAppService : IApplicationService
    {
        Task CreateOrder(CreateOrderInputDTO input);
        Task UpdateOrder(UpdateOrderInputDTO input);
        Task DeleteOrder( int id);
        Task<OrderDTO> GetOrderById( int id);
    }
}
