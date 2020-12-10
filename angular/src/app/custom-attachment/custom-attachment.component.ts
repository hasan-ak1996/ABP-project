import { Component, forwardRef, OnInit } from '@angular/core';
import { ControlValueAccessor, NG_VALUE_ACCESSOR} from '@angular/forms';


@Component({
  selector: 'custom-attachment',
  templateUrl: './custom-attachment.component.html',
  styleUrls: ['./custom-attachment.component.scss'],
  providers: [     
    {       provide: NG_VALUE_ACCESSOR, 
            useExisting: forwardRef(() => CustomAttachmentComponent),
            multi: true     
    } 
  ]
})
export class CustomAttachmentComponent implements ControlValueAccessor  {
  onChange: any = () => {}
  onTouch: any = () => {}
  val= ""
  
  constructor() { }

  set value(val){
    if( val !== undefined && this.val !== val){
    this.val = val
    this.onChange(val)
    this.onTouch(val);
    
    }
  }
  writeValue(value: any): void {
    this.value = value;
  }
  registerOnChange(fn: any): void {
    this.onChange = fn;
  }
  registerOnTouched(fn: any): void {
    this.onTouch = fn
  }
  setDisabledState?(isDisabled: boolean): void {
    throw new Error('Method not implemented.');
  }

  ngOnInit(): void {
  }

}
