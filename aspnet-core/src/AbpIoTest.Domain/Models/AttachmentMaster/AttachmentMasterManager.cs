using AttachmentMasterFolder;
using InterfaceAttachmentMasterManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Services;
using Microsoft.EntityFrameworkCore;

namespace AttachmentMasterManager
{
    public class AttachmentMasterManager : DomainService, IAttachmentMasterManager
    {
        private readonly IRepository<AttachmentMaster> _attachmentMasterRepository;

        public AttachmentMasterManager(IRepository<AttachmentMaster> attachmentMasterRepository)
        {
            _attachmentMasterRepository = attachmentMasterRepository;
        }
        public async Task<AttachmentMasterFolder.AttachmentMaster> CreateFolder(AttachmentMasterFolder.AttachmentMaster entity)
        {
            return await _attachmentMasterRepository.InsertAsync(entity);
        }

        public async Task<AttachmentMasterFolder.AttachmentMaster> GetFolderById(int id)
        {
            return await _attachmentMasterRepository.WithDetails(x => x.Files)
                 .Where(i => i.Id == id).FirstOrDefaultAsync();
        }

        public async Task<AttachmentMaster> GetLastFolderCreated()
        {
            var lasCreationTime = _attachmentMasterRepository.Max(o => o.CreationTime);
            var folder = await _attachmentMasterRepository.FirstOrDefaultAsync(o => o.CreationTime == lasCreationTime);
            return folder;
        }
    }
}
