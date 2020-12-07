using AbpIoTest.Item;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace AbpIoTest.Order
{
    public class OrderDTO : AuditedEntityDto<int>
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string OrderNo { get; set; }
        [Required]
        public string OrderDate { get; set; }
        [Required]
        public string EmpolyeeName { get; set; }
        [Required]
        public decimal TotalPrice { get; set; }
        public bool IsSubmit { get; set; }

        public virtual List<ItemDTO> Items { get; set; }
    }
}
