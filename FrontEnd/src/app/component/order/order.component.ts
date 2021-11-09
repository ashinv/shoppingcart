import { HttpClient } from '@angular/common/http';
import { OrderModule } from './../../model/order/order.module';
import { Component, OnInit } from '@angular/core';
import { CartService } from 'src/app/service/cart.service';
@Component({
  selector: 'app-order',
  templateUrl: './order.component.html',
  styleUrls: ['./order.component.scss']
})
export class OrderComponent implements OnInit {
 
  item: OrderModule =new OrderModule();
  constructor(private cartService : CartService,private httpclient:HttpClient) { }

  ngOnInit(): void {
    this.item.subtotal=this.grandtotal();
    this.item.shipping=10;
    this.item.tax=0;
    this.item.totalamt=this.item.subtotal+this.item.shipping+this.item.tax;
    this.item.totalamt=Number(this.item.totalamt.toFixed(2));
    
  }
  grandtotal():number{
    return this.cartService.grandTotal
  }
  addorder(){
    console.log(this.item);
    this.httpclient.post<any>("http://localhost:64413/api/Orders",this.item)
  .subscribe(res=>{
    console.log("Order details saved Successfull");
  },err=>{
    console.log("Something went wrong");
  })
  }
}
