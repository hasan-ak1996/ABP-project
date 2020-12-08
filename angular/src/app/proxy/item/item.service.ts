import type { CreateItemInputDTO, ItemDTO, UpdateItemInputDTO } from './models';
import { RestService } from '@abp/ng.core';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root',
})
export class ItemService {
  apiName = 'Default';

  createItemByInput = (input: CreateItemInputDTO) =>
    this.restService.request<any, void>({
      method: 'POST',
      url: `/api/app/item/item`,
      body: input,
    },
    { apiName: this.apiName });

  deleteItemById = (id: number) =>
    this.restService.request<any, void>({
      method: 'DELETE',
      url: `/api/app/item/${id}/item`,
    },
    { apiName: this.apiName });

  getAllItemsForOrderByOrderId = (orderId: number) =>
    this.restService.request<any, ItemDTO[]>({
      method: 'GET',
      url: `/api/app/item/items-for-order/${orderId}`,
    },
    { apiName: this.apiName });

  getItemByIdById = (id: number) =>
    this.restService.request<any, ItemDTO>({
      method: 'GET',
      url: `/api/app/item/${id}/item-by-id`,
    },
    { apiName: this.apiName });

  updateItemByIdAndInput = (id: number, input: UpdateItemInputDTO) =>
    this.restService.request<any, void>({
      method: 'PUT',
      url: `/api/app/item/${id}/item`,
      body: input,
    },
    { apiName: this.apiName });

  constructor(private restService: RestService) {}
}
