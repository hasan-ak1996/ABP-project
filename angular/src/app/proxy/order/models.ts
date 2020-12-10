import type { AuditedEntityDto, PagedAndSortedResultRequestDto } from '@abp/ng.core';

export interface CreateOrderInputDTO {
  name: string;
  orderNo: string;
  creationTime?: string;
  isSubmit: boolean;
  orderDate: string;
  empolyeeName: string;
  totalPrice: number;
  attachmentMasterId: number;
}

export interface GetOrderListDto extends PagedAndSortedResultRequestDto {
  keyword?: string;
  isSubmit?: boolean;
  maxResultCount: number;
  skipCount: number;
}

export interface OrderDTO extends AuditedEntityDto<number> {
  name: string;
  orderNo: string;
  orderDate: string;
  empolyeeName: string;
  totalPrice: number;
  isSubmit: boolean;
  attachmentMasterId: number;
}

export interface UpdateOrderInputDTO {
  name: string;
  orderNo: string;
  orderDate: string;
  isSubmit: boolean;
  lastModificationTime?: string;
  empolyeeName: string;
  totalPrice: number;
}
