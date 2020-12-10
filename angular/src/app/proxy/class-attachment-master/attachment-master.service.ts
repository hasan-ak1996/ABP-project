import { RestService } from '@abp/ng.core';
import { Injectable } from '@angular/core';
import type { AttachmentMasterDTO } from '../attachment-master/models';

@Injectable({
  providedIn: 'root',
})
export class AttachmentMasterService {
  apiName = 'Default';

  createFolderByEntityName = (entityName: string) =>
    this.restService.request<any, void>({
      method: 'POST',
      url: `/api/app/attachment-master/folder`,
      params: { entityName: entityName },
    },
    { apiName: this.apiName });

  getFolderByIdById = (id: number) =>
    this.restService.request<any, AttachmentMasterDTO>({
      method: 'GET',
      url: `/api/app/attachment-master/${id}/folder-by-id`,
    },
    { apiName: this.apiName });

  getLastFolderCreated = () =>
    this.restService.request<any, AttachmentMasterDTO>({
      method: 'GET',
      url: `/api/app/attachment-master/last-folder-created`,
    },
    { apiName: this.apiName });

  constructor(private restService: RestService) {}
}
