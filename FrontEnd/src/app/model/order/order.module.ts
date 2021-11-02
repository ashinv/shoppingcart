import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';



@NgModule({
  declarations: [],
  imports: [
    CommonModule
  ]
})
export class OrderModule {

  subtotal:number=0;
  shipping:number=0;
  tax:number=0;
  totalamt:number=0;
 }
