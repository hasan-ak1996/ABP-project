using InterfaceAttachmentDetailManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Services;
using Microsoft.EntityFrameworkCore;
using Volo.Abp;

namespace classAttachmentDetailManager
{
    public class AttachmentDetailManager : DomainService, IAttachemntDetailManager
    {
        private readonly IRepository<AttachmentDetail.AttachmentDetail> _attachmentDetailRepository;

        public AttachmentDetailManager(IRepository<AttachmentDetail.AttachmentDetail> attachmentDetailRepository)
        {
            _attachmentDetailRepository = attachmentDetailRepository;
        }

        public async Task CreateFile(AttachmentDetail.AttachmentDetail entity)
        {
            await _attachmentDetailRepository.InsertAsync(entity);
        }

        public async Task<AttachmentDetail.AttachmentDetail> GetFileById(int id)
        {
            return await _attachmentDetailRepository.FirstOrDefaultAsync(f => f.Id == id);
        }

        public async Task UpdateFile(global::AttachmentDetail.AttachmentDetail entity)
        {
            await _attachmentDetailRepository.UpdateAsync(entity);
        }
    }
}
