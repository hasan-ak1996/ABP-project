import type { CreateOrderInputDTO, OrderDTO, UpdateOrderInputDTO } from './models';
import { RestService } from '@abp/ng.core';
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

  getOrderByIdById = (id: number) =>
    this.restService.request<any, OrderDTO>({
      method: 'GET',
      url: `/api/app/order/${id}/order-by-id`,
    },
    { apiName: this.apiName });

  updateOrderByInput = (input: UpdateOrderInputDTO) =>
    this.restService.request<any, void>({
      method: 'PUT',
      url: `/api/app/order/order`,
      body: input,
    },
    { apiName: this.apiName });

  constructor(private restService: RestService) {}
}
