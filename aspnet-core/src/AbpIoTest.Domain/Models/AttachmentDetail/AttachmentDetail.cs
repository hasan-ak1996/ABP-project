using AttachmentMasterFolder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities.Auditing;

namespace AttachmentDetail
{
    public class AttachmentDetail : FullAuditedAggregateRoot<int>
    {
        public string FileName { get; set; }
        public byte[] File { get; set; }
        public string Extension { get; set; }
        public decimal TemporaryStatus { get; set; }
        public decimal FileSize { get; set; }
        public AttachmentMaster AttachmentMaster { get; set; }
        public int AttachmentMasterId { get; set; }
    }
}
