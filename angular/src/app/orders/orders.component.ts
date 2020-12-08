import { ListService, PagedResultDto } from '@abp/ng.core';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { OrderDTO, OrderService } from '@proxy/order';

@Component({
  selector: 'app-orders',
  templateUrl: './orders.component.html',
  styleUrls: ['./orders.component.scss'],
  providers: [ListService],
})
export class OrdersComponent implements OnInit {
  order = { items: [], totalCount: 0 } as PagedResultDto<OrderDTO>;
  advancedFiltersVisible = false;

  constructor(public readonly list: ListService, private orderService: OrderService,
    private router : Router,
    private route : ActivatedRoute,) { }

  ngOnInit(): void {
    const orderStreamCreator = (query) => this.orderService.getAllOrdersByInput(query);
 
    this.list.hookToQuery(orderStreamCreator).subscribe((response) => {
      this.order = response;
      console.log(this.order.items);
      console.log(   this.list.filter)
    });
  }
  goToCreateOrder(){
    this.router.navigate(['/create-order']);
  }
  deleteOrder(id){
    console.log(id)
    this.orderService.deleteOrderById(id).subscribe(()=>{
      this.list.get()
    })
  }
  editOrder(id){
    this.router.navigate(['edit-order' , id ]);
  }
  

}
