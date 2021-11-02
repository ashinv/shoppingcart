
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';



@NgModule({
  declarations: [],
  imports: [
    CommonModule
  ]
})
export class CartsModule {
 

  id:number=0;
  title:string="";
  price:number=0;
  description:string="";
  category:string="";
  image:string="";
  quantity:number=0;
  total:number=0;
 }
