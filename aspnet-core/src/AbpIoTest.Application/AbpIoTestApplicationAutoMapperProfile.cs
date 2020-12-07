using AbpIoTest.Item;
using AbpIoTest.Order;
using AutoMapper;
using OrderEntity;

namespace AbpIoTest
{
    public class AbpIoTestApplicationAutoMapperProfile : Profile
    {
        public AbpIoTestApplicationAutoMapperProfile()
        {
            CreateMap<OrderEntity. Order, OrderDTO>();
            CreateMap<CreateOrderInputDTO, OrderEntity.Order>();
            CreateMap<UpdateOrderInputDTO, OrderEntity.Order>();

            CreateMap<ItemEntity.Item, ItemDTO>();
            CreateMap<CreateItemInputDTO, ItemEntity.Item>();
            CreateMap<UpdateItemInputDTO, ItemEntity.Item>();

        }
    }
}
