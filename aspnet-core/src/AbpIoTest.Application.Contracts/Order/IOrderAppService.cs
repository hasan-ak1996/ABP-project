using AbpIoTest.Order;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace InterfaceOrderAppService
{
    public interface IOrderAppService : IApplicationService
    {
        Task<PagedResultDto<OrderDTO>> GetAllOrders(GetOrderListDto input);
        Task CreateOrder(CreateOrderInputDTO input);
        Task UpdateOrder(int id,UpdateOrderInputDTO input);
        Task DeleteOrder( int id);
        Task<OrderDTO> GetLastOrderCreated();
        Task<OrderDTO> GetOrderById( int id);
    }
}
