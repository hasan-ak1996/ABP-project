using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities.Auditing;

namespace AttachmentMasterFolder
{
    public class AttachmentMaster : FullAuditedAggregateRoot<int>
    {
        public string EntityName { get; set; }
        public List<AttachmentDetail.AttachmentDetail> Files { get; set; }

        public AttachmentMaster()
        {
            Files = new List<AttachmentDetail.AttachmentDetail>();
        }
    }
}
