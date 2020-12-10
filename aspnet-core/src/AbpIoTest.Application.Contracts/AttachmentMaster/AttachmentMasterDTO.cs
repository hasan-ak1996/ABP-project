using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace AbpIoTest.AttachmentMaster
{
    public class AttachmentMasterDTO : AuditedEntityDto<int>
    {
        public List<AttachmentDetailDTO.AttachmentDetailDTO> Files { get; set; }
    }
}
