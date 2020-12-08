import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { EditOrderRoutingModule } from './edit-order-routing.module';
import { EditOrderComponent } from './edit-order.component';
import { SharedModule } from '../shared/shared.module';


@NgModule({
  declarations: [EditOrderComponent],
  imports: [
    CommonModule,
    EditOrderRoutingModule,
    SharedModule
  ]
})
export class EditOrderModule { }
