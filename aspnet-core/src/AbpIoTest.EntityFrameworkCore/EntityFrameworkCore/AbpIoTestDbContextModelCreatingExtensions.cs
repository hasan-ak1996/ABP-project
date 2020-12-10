using AttachmentMasterFolder;
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
                b.ConfigureByConvention();
               // b.HasOne<AttachmentMaster>().WithMany().HasForeignKey(t => t.AttachmentMasterId).IsRequired();
            });


            builder.Entity<ItemEntity.Item>(b =>

            {
                b.ToTable(AbpIoTestConsts.DbTablePrefix + "Item", AbpIoTestConsts.DbSchema);
                b.ConfigureByConvention();
                b.HasOne<OrderEntity.Order>().WithMany().HasForeignKey(x => x.OrderId).IsRequired();
            });


            builder.Entity<AttachmentMaster>(b =>
            {
                b.ToTable(AbpIoTestConsts.DbTablePrefix + "AttachmentMaster", AbpIoTestConsts.DbSchema);
                b.ConfigureByConvention();
                b.HasMany(x => x.Files)
                .WithOne(x => x.AttachmentMaster)
                .HasForeignKey(x => x.AttachmentMasterId)
                .IsRequired();
            });


            builder.Entity<AttachmentDetail.AttachmentDetail>(b =>
            {
                b.ToTable(AbpIoTestConsts.DbTablePrefix + "AttachmentDetail", AbpIoTestConsts.DbSchema);
                b.ConfigureByConvention();
               
            });

        }
    }
}