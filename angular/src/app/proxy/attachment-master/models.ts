import type { AuditedEntityDto } from '@abp/ng.core';
import type { AttachmentDetailDTO } from '../attachment-detail-dto/models';

export interface AttachmentMasterDTO extends AuditedEntityDto<number> {
  files: AttachmentDetailDTO[];
}
