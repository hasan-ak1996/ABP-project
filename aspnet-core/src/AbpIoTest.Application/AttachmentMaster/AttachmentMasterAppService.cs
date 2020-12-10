using AbpIoTest.AttachmentMaster;
using AttachmentMasterFolder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace ClassAttachmentMaster
{
    public class AttachmentMasterAppService : ApplicationService , IAttachmentMasterAppService
    {
        private readonly AttachmentMasterManager.AttachmentMasterManager _attachmentMasterManager;

        public AttachmentMasterAppService(AttachmentMasterManager.AttachmentMasterManager attachmentMasterManager)
        {
            _attachmentMasterManager = attachmentMasterManager;
        }
        public async Task CreateFolder(string entityName)
        {
            AttachmentMaster attachmentMaster = new AttachmentMaster
            {
                EntityName = entityName
            };
            await _attachmentMasterManager.CreateFolder(attachmentMaster);
        }
        public async Task<AttachmentMasterDTO> GetFolderById(int id)
        {
            var folder = await _attachmentMasterManager.GetFolderById(id);
            AttachmentMasterDTO output = ObjectMapper.Map<AttachmentMaster, AttachmentMasterDTO>(folder);
            return output;
        }

        public async Task<AttachmentMasterDTO> GetLastFolderCreated()
        {
            var folder = await _attachmentMasterManager.GetLastFolderCreated();
            AttachmentMasterDTO output = ObjectMapper.Map<AttachmentMaster, AttachmentMasterDTO>(folder);
            return output;
        }
    }
}
