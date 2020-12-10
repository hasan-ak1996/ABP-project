import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { CreateOrderRoutingModule } from './create-order-routing.module';
import { SharedModule } from '../shared/shared.module';
import { CreateOrderComponent } from './create-order.component';
import {MatFormFieldModule} from '@angular/material/form-field';
import {MatInputModule} from '@angular/material/input';
import {MatSelectModule} from '@angular/material/select';
import {MatDatepickerModule} from '@angular/material/datepicker';
import {MatCheckboxModule} from '@angular/material/checkbox';
import {MatButtonModule} from '@angular/material/button';
import { MaterialFileInputModule } from 'ngx-material-file-input';

@NgModule({
  declarations: [CreateOrderComponent],
  imports: [
    CommonModule,
    CreateOrderRoutingModule,
    SharedModule,
    MatCheckboxModule,
    MatFormFieldModule,
    MatInputModule,
    MatSelectModule,
    MatDatepickerModule,
    MatButtonModule,
    MaterialFileInputModule,
  ]
})
export class CreateOrderModule { }
