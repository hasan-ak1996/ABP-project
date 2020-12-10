using AttachmentMasterFolder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Services;

namespace InterfaceAttachmentMasterManager
{
    public interface IAttachmentMasterManager : IDomainService
    {
        Task<AttachmentMaster> GetFolderById(int id);
        Task<AttachmentMaster> CreateFolder(AttachmentMaster entity);

        Task<AttachmentMaster> GetLastFolderCreated();
    }
}
