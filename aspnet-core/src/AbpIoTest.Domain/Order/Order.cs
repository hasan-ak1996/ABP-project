using ItemEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities.Auditing;

namespace OrderEntity
{
    public class Order : FullAuditedAggregateRoot<int>
    {
        public string Name { get; set; }
        public string OrderNo { get; set; }
        public DateTime OrderDate { get; set; }
        public bool IsSubmit { get; set; }
        public string EmpolyeeName { get; set; }
        public decimal TotalPrice { get; set; }

    }
}
