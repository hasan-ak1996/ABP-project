﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AbpIoTest.Item
{
    public class CreateItemInputDTO
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public DateTime CreationTime { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        public int Quantity { get; set; }

        [Required]
        public decimal TotalPrice { get; set; }
        public int OrderId { get; set; }
    }
}
