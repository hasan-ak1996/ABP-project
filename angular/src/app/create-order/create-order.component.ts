import { SessionStateService } from '@abp/ng.core';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { AttachmentMasterService } from '@proxy/class-attachment-master';
import { CreateOrderInputDTO, OrderDTO, OrderService } from '@proxy/order';
import { FileService } from '../file-service.service';

@Component({
  selector: 'app-create-order',
  templateUrl: './create-order.component.html',
  styleUrls: ['./create-order.component.scss']
})
export class CreateOrderComponent implements OnInit {
  orderId : number;
  filesToUpload  : File[];
  fileResult : any;
  order = {} as CreateOrderInputDTO;
 
  file;
  users : string [] = ['hasan','ahmad','yaser','wael','omar'];
  isValidFormSubmitted = null;
  constructor( private router: Router,
    private orderService: OrderService,
    private attachmentMasterService: AttachmentMasterService,
    private fileService: FileService
    
    ) { }
    
  ngOnInit(): void {
    this.order.totalPrice = 0;
  }

  goToViewOrders(){
    this.router.navigate(['/orders']);
  }


  public fileChange(files) {
    this.filesToUpload = files;
    console.log(this.filesToUpload )
  }
  save(): void {
     this.attachmentMasterService.createFolderByEntityName("Order").subscribe(()=>{

     });
     var formData = new FormData();
     if(this.filesToUpload == null){
      formData.append('Files', null);
    }else{
      Array.from(this.filesToUpload).map((file) => {
        return formData.append('Files', file);

      });
    }
    this.fileService.UploadFiles(formData).subscribe(res =>{
      
    })
    var attachmentId = new Number() ;
    
    this.attachmentMasterService.getLastFolderCreated().subscribe((res) => {
      this.fileResult=res;
      attachmentId = this.fileResult.id;
      this.order.attachmentMasterId =   this.fileResult.id;
      this.orderService.createOrderByInput(this.order).subscribe(()=>{
        this.orderService.getLastOrderCreated().subscribe((res)=>{
          this.orderId = res.id;
          this.router.navigate(['edit-order' , this.orderId ]);
        })
       })
      //
    })
    
  

    
 

    }

}
