using ItemEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Services;

namespace InterfaceItemManager
{
    public interface IItemManager : IDomainService
    {
        Task<Item> GetItemById(int id);
        Task CreateItem(Item entity);
        Task DeleteItem(int id);
        Task UpdateItem(Item entity);
    }
}
