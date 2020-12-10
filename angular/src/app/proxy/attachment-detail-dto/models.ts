import type { AuditedEntityDto } from '@abp/ng.core';

export interface AttachmentDetailDTO extends AuditedEntityDto<number> {
  fileName?: string;
  extension?: string;
  temporaryStatus: number;
  fileSize: number;
  attachmentMasterId: number;
}
