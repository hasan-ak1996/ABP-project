import type { AuditedEntityDto } from '@abp/ng.core';

export interface CreateItemInputDTO {
  name: string;
  creationTime: string;
  price: number;
  quantity: number;
  totalPrice: number;
  orderId: number;
}

export interface ItemDTO extends AuditedEntityDto<number> {
  name?: string;
  price: number;
  quantity: number;
  totalPrice: number;
  orderId: number;
}

export interface UpdateItemInputDTO {
  name: string;
  price: number;
  quantity: number;
  totalPrice: number;
  lastModificationTime?: string;
}
