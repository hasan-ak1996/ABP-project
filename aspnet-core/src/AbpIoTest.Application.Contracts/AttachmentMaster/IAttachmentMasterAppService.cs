using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace AbpIoTest.AttachmentMaster
{
    public interface IAttachmentMasterAppService : IApplicationService
    {
        Task CreateFolder(string entityName);
        Task<AttachmentMasterDTO> GetFolderById(int id);
        Task<AttachmentMasterDTO> GetLastFolderCreated();
    }
}
