import { SessionStateService } from '@abp/ng.core';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { CreateOrderInputDTO, OrderService } from '@proxy/order';

@Component({
  selector: 'app-create-order',
  templateUrl: './create-order.component.html',
  styleUrls: ['./create-order.component.scss']
})
export class CreateOrderComponent implements OnInit {
  registerForm : FormGroup;
  orderId : number;
  users : string [] = ['hasan','ahmad','yaser','wael','omar'];
  isValidFormSubmitted = null;
  constructor( private router: Router,
    private formBuilder : FormBuilder,
    private orderService: OrderService
    
    ) { }
    
  ngOnInit(): void {
    
    this.registerForm = this.formBuilder.group({
      'name' :new FormControl('',[
        Validators.required
      ]), 
      'orderNo' :new FormControl('',[
        Validators.required
      ]),
      'empolyeeName' :new FormControl('',[
        Validators.required
      ]),
      'totalPrice' :new FormControl(''),

      'datetime' :new FormControl('',[
        Validators.required
      ]),
      'isSubmit' :new FormControl(''),
      
    });
    this.registerForm.get("totalPrice").setValue(0);
  }

  goToViewOrders(){
    this.router.navigate(['/orders']);
  }

  save(): void {
    console.log(this.registerForm.get("isSubmit").value )
    this.isValidFormSubmitted = false;
     if (this.registerForm.invalid) {
        return;
     }
     this.isValidFormSubmitted = true;

     if(this.registerForm.get("isSubmit").value == ''){
      this.registerForm.get("isSubmit").setValue(false);
     }
     this.orderService.createOrderByInput(this.registerForm.value).subscribe(()=>{
      this.orderService.getLastOrderCreated().subscribe((res)=>{
        this.orderId = res.id;
        this.router.navigate(['edit-order' , this.orderId ]);
        console.log(res.id)
      })
     })

    }

}
