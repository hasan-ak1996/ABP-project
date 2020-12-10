using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Services;

namespace InterfaceAttachmentDetailManager
{
    public interface IAttachemntDetailManager : IDomainService
    {
        Task CreateFile(AttachmentDetail.AttachmentDetail entity);
        Task<AttachmentDetail.AttachmentDetail> GetFileById(int id);
        Task UpdateFile(AttachmentDetail.AttachmentDetail entity);
    }
}
