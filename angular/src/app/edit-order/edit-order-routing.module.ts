import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { EditOrderComponent } from './edit-order.component';

const routes: Routes = [{ path: '', component: EditOrderComponent }];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class EditOrderRoutingModule { }
