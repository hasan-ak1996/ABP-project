using ItemEntity;
using Microsoft.EntityFrameworkCore;
using OrderEntity;
using Volo.Abp;
using Volo.Abp.EntityFrameworkCore.Modeling;

namespace AbpIoTest.EntityFrameworkCore
{
    public static class AbpIoTestDbContextModelCreatingExtensions
    {
        public static void ConfigureAbpIoTest(this ModelBuilder builder)
        {
            Check.NotNull(builder, nameof(builder));

            /* Configure your own tables/entities inside here */

            builder.Entity<OrderEntity.Order>(b =>
            {
                b.ToTable(AbpIoTestConsts.DbTablePrefix + "Order", AbpIoTestConsts.DbSchema);
                b.ConfigureByConvention(); //auto configure for the base class props
                //...
            });


            builder.Entity<ItemEntity.Item>(b =>
            {
                b.ToTable(AbpIoTestConsts.DbTablePrefix + "Item", AbpIoTestConsts.DbSchema);
                b.ConfigureByConvention();
                b.HasOne<OrderEntity.Order>().WithMany().HasForeignKey(x => x.OrderId).IsRequired();
            });
        }
    }
}