using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AbpIoTest.Order
{
    public class CreateOrderInputDTO
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string OrderNo { get; set; }


        public DateTime CreationTime { get; set; }

        public bool IsSubmit { get; set; }

        [Required]
        public DateTime OrderDate { get; set; }

        [Required]
        public string EmpolyeeName { get; set; }

        [Required]
        public decimal TotalPrice { get; set; }
        public int AttachmentMasterId { get; set; }
    }
}
