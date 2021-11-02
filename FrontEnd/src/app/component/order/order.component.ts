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
    
  }
  grandtotal():number{
    return this.cartService.grandTotal
  }
  additem(){
    console.log(this.item);
    return this.httpclient.post<OrderModule>("http://localhost:50260/api/Orders",this.item);
  }
}
