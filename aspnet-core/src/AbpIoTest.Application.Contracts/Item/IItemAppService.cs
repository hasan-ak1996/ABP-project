using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace AbpIoTest.Item
{
    public interface IItemAppService : IApplicationService
    {
        Task CreateItem(CreateItemInputDTO input);
        Task UpdateItem(UpdateItemInputDTO input);
        Task DeleteItem(int id);
        Task<ItemDTO> GetItemById( int id);
    }
}
