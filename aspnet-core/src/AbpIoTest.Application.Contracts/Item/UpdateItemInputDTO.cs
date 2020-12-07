using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace AbpIoTest.Item
{
    public class UpdateItemInputDTO : EntityDto<int>
    {

        [Required]
        public string Name { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        public int Quantity { get; set; }

        [Required]
        public decimal TotalPrice { get; set; }


        public DateTime? LastModificationTime { get; set; }
    }
}
