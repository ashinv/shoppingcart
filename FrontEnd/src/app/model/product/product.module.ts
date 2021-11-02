import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';



@NgModule({
  declarations: [],
  imports: [
    CommonModule
  ]
})
export class ProductModule { 
  id:number=0;
  title:string="";
  description:string="";
  price:number=0;
  category:string="";
  image:string="";
}
