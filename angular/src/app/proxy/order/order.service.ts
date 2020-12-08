import type { CreateOrderInputDTO, GetOrderListDto, OrderDTO, UpdateOrderInputDTO } from './models';
import { RestService } from '@abp/ng.core';
import type { PagedResultDto } from '@abp/ng.core';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root',
})
export class OrderService {
  apiName = 'Default';

  createOrderByInput = (input: CreateOrderInputDTO) =>
    this.restService.request<any, void>({
      method: 'POST',
      url: `/api/app/order/order`,
      body: input,
    },
    { apiName: this.apiName });

  deleteOrderById = (id: number) =>
    this.restService.request<any, void>({
      method: 'DELETE',
      url: `/api/app/order/${id}/order`,
    },
    { apiName: this.apiName });

  getAllOrdersByInput = (input: GetOrderListDto) =>
    this.restService.request<any, PagedResultDto<OrderDTO>>({
      method: 'GET',
      url: `/api/app/order/orders`,
      params: { keyword: input.keyword, isSubmit: input.isSubmit, maxResultCount: input.maxResultCount, skipCount: input.skipCount, sorting: input.sorting },
    },
    { apiName: this.apiName });

  getLastOrderCreated = () =>
    this.restService.request<any, OrderDTO>({
      method: 'GET',
      url: `/api/app/order/last-order-created`,
    },
    { apiName: this.apiName });

  getOrderByIdById = (id: number) =>
    this.restService.request<any, OrderDTO>({
      method: 'GET',
      url: `/api/app/order/${id}/order-by-id`,
    },
    { apiName: this.apiName });

  updateOrderByIdAndInput = (id: number, input: UpdateOrderInputDTO) =>
    this.restService.request<any, void>({
      method: 'PUT',
      url: `/api/app/order/${id}/order`,
      body: input,
    },
    { apiName: this.apiName });

  constructor(private restService: RestService) {}
}
