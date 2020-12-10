using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace AttachmentDetailDTO
{
    public class AttachmentDetailDTO : AuditedEntityDto<int>
    {
        public string FileName { get; set; }
        public string Extension { get; set; }
        public decimal TemporaryStatus { get; set; }
        public decimal FileSize { get; set; }
        public int AttachmentMasterId { get; set; }
    }
}
