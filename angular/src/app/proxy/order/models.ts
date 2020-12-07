import type { AuditedEntityDto } from '@abp/ng.core';
import type { ItemDTO } from '../item/models';

export interface CreateOrderInputDTO {
  name: string;
  orderNo: string;
  creationTime?: string;
  isSubmit: boolean;
  orderDate: string;
  empolyeeName: string;
  totalPrice: number;
}

export interface OrderDTO extends AuditedEntityDto<number> {
  name: string;
  orderNo: string;
  orderDate: string;
  empolyeeName: string;
  totalPrice: number;
  isSubmit: boolean;
  items: ItemDTO[];
}

export interface UpdateOrderInputDTO {
  name: string;
  orderNo: string;
  orderDate: string;
  isSubmit: boolean;
  lastModificationTime: string;
  empolyeeName: string;
  totalPrice: number;
}
