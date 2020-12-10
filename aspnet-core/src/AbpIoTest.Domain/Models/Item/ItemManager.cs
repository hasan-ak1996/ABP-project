using InterfaceItemManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Services;
using Microsoft.EntityFrameworkCore;


namespace AbpIoTest.Item
{
    public class ItemManager : DomainService, IItemManager
    {
        private readonly IRepository<ItemEntity.Item,int> itemRepository;

        public ItemManager(IRepository<ItemEntity.Item,int> itemRepository)
        {
            this.itemRepository = itemRepository;
        }
        public async Task CreateItem(ItemEntity.Item entity)
        {
            var item =await itemRepository.FirstOrDefaultAsync(i => i.Id == entity.Id);
            if (item != null)
            {
                throw new UserFriendlyException("already Exist");
            }
            else
            {
                 await itemRepository.InsertAsync(entity);
            }
        }

        public async Task DeleteItem(int id)
        {
            var item = await itemRepository.FirstOrDefaultAsync(i => i.Id == id);

            if (item == null)
            {
                throw new UserFriendlyException("No item Found");
            }
            else
            {
                await itemRepository.DeleteAsync(item);
            }
        }

        public async Task<List<ItemEntity.Item>> GetAllItemsForOrder(int orderId)
        {
            var orders =await itemRepository.Where(o => o.OrderId == orderId).ToListAsync();
            return orders;
        }

        public async Task<ItemEntity.Item> GetItemById(int id)
        {
            return await itemRepository.GetAsync(id);
        }

        public async Task UpdateItem(ItemEntity.Item entity)
        {
            await  itemRepository.UpdateAsync(entity);
        }
    }
}
