using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace AbpIoTest.Order
{
    public class GetOrderListDto : PagedAndSortedResultRequestDto
    {
        public string keyword { get; set; }
        public bool? IsSubmit { get; set; }
        public override int MaxResultCount { get => base.MaxResultCount; set => base.MaxResultCount = value; }
        public override int SkipCount { get => base.SkipCount; set => base.SkipCount = value; }
    }
}
