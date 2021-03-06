﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace AbpIoTest.Order
{
    public class UpdateOrderInputDTO 
    {

        [Required]
        public string Name { get; set; }

        [Required]
        public string OrderNo { get; set; }

        [Required]
        public DateTime OrderDate { get; set; }

        public bool IsSubmit { get; set; }
        public DateTime LastModificationTime { get; set; }

        [Required]
        public string EmpolyeeName { get; set; }

        [Required]
        public decimal TotalPrice { get; set; }
    }
}
