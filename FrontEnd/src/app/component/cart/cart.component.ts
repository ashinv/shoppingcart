import { CartsModule } from './../../model/carts/carts.module';

import { Component, OnInit } from '@angular/core';
import { CartService } from 'src/app/service/cart.service';
import { interval, Subscription } from 'rxjs';

@Component({
  selector: 'app-cart',
  templateUrl: './cart.component.html',
  styleUrls: ['./cart.component.scss']
})
export class CartComponent implements OnInit {

  public updateSubscription: Subscription | undefined;
  public products : any;
  public grandTotal !: number;
  constructor(private cartService : CartService) { }

  ngOnInit(): void {
    this.updateSubscription = interval(2000).subscribe(
      (val) => { this.fetchcart()});
  }
  fetchcart(){
    this.cartService.getProducts()
    .subscribe(res=>{
      this.products = res;
      this.grandTotal = this.cartService.getTotalPrice();
    })
   
  }
  grandtotal():number{
    return this.cartService.grandTotal
  }
  removeItem(id:number){
    this.cartService.removeCartItem(id)
    .subscribe(res => {
    
      console.log(res);
      alert("Removed From the Cart");
    }, error => {
      alert("Something Went Wrong");
    }
    )
  }
 additem(item:CartsModule){
   item.quantity+=1;
   item.total+=item.price;
   this.cartService.updateCart(item)
   .subscribe(res => {
    
    console.log(res);
    alert("Cart Updated");
  }, error => {
    alert("Something Went Wrong");
  }
  )


 }

}

