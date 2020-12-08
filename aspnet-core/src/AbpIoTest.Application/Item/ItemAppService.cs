using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace AbpIoTest.Item
{
    public class ItemAppService : ApplicationService, IItemAppService
    {
        private readonly ItemManager itemManager;

        public ItemAppService(ItemManager itemManager)
        {
            this.itemManager = itemManager;
        }
        public async Task CreateItem(CreateItemInputDTO input)
        {
            ItemEntity.Item output = ObjectMapper.Map<CreateItemInputDTO, ItemEntity.Item>(input);

            await itemManager.CreateItem(output);
        }

        public async Task DeleteItem(int id)
        {
            await itemManager.DeleteItem(id);
        }

        public async Task<List<ItemDTO>> GetAllItemsForOrder(int orderId)
        {
            var orders =await itemManager.GetAllItemsForOrder(orderId);
            List<ItemDTO> output = ObjectMapper.Map<List<ItemEntity.Item>, List<ItemDTO>>(orders);
            return output;
        }

        public async Task<ItemDTO> GetItemById(int id)
        {
            var item = await itemManager.GetItemById(id);

            ItemDTO output = ObjectMapper.Map<ItemEntity.Item, ItemDTO>(item);
            return output;
        }

        public async Task UpdateItem(int id,UpdateItemInputDTO input)
        {
            var item = await itemManager.GetItemById(id);

            item.Name = input.Name;
            item.Price = input.Price;
            item.Quantity = input.Quantity;
            item.TotalPrice = input.TotalPrice;

            await itemManager.UpdateItem(item);

  

        }
    }
}
