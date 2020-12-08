import { ConfirmationService, Confirmation } from '@abp/ng.theme.shared';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Params, Router } from '@angular/router';
import { ItemDTO, ItemService } from '@proxy/item';
import { OrderDTO, OrderService, UpdateOrderInputDTO } from '@proxy/order';

@Component({
  selector: 'app-edit-order',
  templateUrl: './edit-order.component.html',
  styleUrls: ['./edit-order.component.scss']
})
export class EditOrderComponent implements OnInit {
  id: number;
  order = {} as OrderDTO;
  updatedOrder = {} as UpdateOrderInputDTO
  item = {} as ItemDTO;
  items : ItemDTO[] =[];
  users : string [] = ['hasan','ahmad','yaser','wael','omar'];
  isModalOpen = false; 
  Itemform: FormGroup;
  isValidFormSubmitted = null;
  constructor(  private _router: Router,
    private _activatedRoute: ActivatedRoute,
    private orderService: OrderService,
    private itemService: ItemService,
    private confirmation : ConfirmationService ,
    private fb: FormBuilder,
    private router: Router,) { }

  ngOnInit(): void {
    this._activatedRoute.params.subscribe((params: Params) => {
      this.id = params['id']; });
      this.orderService.getOrderByIdById(this.id).subscribe((res) =>{
        this.order = res;
        this.itemService.getAllItemsForOrderByOrderId(this.id).subscribe((res) => {
          this.items = res
          this.UpdateTotalPrice()
          console.log( this.items)
        })
        console.log( this.order.orderDate)
      })
      console.log(this.item.id)

  }
  UpdateTotalPrice(){
    this.order.totalPrice = this.items.reduce((prev,curr) => {
      return prev + curr.totalPrice;
    },0);
    this.order.totalPrice = parseInt((this.order.totalPrice).toFixed(2));
  }

  

  save(): void {
    this.updatedOrder.name = this.order.name;
    this.updatedOrder.orderNo  = this.order.orderNo;
    this.updatedOrder.empolyeeName = this.order.empolyeeName;
    this.updatedOrder.totalPrice = this.order.totalPrice;
    this.updatedOrder.orderDate = this.order.orderDate;
    this.updatedOrder.isSubmit =this.order.isSubmit;

    this.orderService.updateOrderByIdAndInput( this.id ,this.updatedOrder).subscribe(()=>{
      this.router.navigate(['/orders']);
    })
  }
  createItem() {
    this.buildForm();
    this.isModalOpen = true;
  }
  editItem(id) {
    this.itemService.getItemByIdById(id).subscribe((res) =>{
      this.item=res;
      this.buildForm();
      this.isModalOpen = true;
    })
  }
  delete(id) {
    this.confirmation.warn('::AreYouSureToDelete', '::AreYouSure').subscribe((status) => {
      if (status === Confirmation.Status.confirm) {
        this.itemService.deleteItemById(id).subscribe(() => {
          this.itemService.getAllItemsForOrderByOrderId(this.id).subscribe((res) => {
            this.items = res
          })
        });
      }
    });
  }
  buildForm() {
    this.Itemform = this.fb.group({
      name: [this.item.id ?  this.item.name : '', Validators.required],
      price: [this.item.id ?  this.item.price : null, Validators.required],
      quantity: [this.item.id ?  this.item.quantity : null, Validators.required],
      totalPrice: [this.item.id ?  this.item.totalPrice : null, Validators.required],
      orderId:[null]
    });
  }
  UpdateTotal(){
    var total = parseInt((this.Itemform.get("quantity").value * this.Itemform.get("price").value).toFixed(2));
    this.Itemform.get("totalPrice").setValue(total);
  }
  saveItem(){
    this.isValidFormSubmitted = false;
    if (this.Itemform.invalid) {
      return;
    }
    this.isValidFormSubmitted = true;

    this.Itemform.get("orderId").setValue(this.id);
    const request = this.item.id
    ? this.itemService.updateItemByIdAndInput(this.item.id, this.Itemform.value)
    : this.itemService.createItemByInput(this.Itemform.value);

    request.subscribe(() => {
      this.isModalOpen = false;
      this.Itemform.get("name").setValue('');
      this.item.id =undefined;
      this.itemService.getAllItemsForOrderByOrderId(this.id).subscribe((res) => {
        this.items = res
      })
    });
  }

}
