import { Component, OnInit } from '@angular/core';
import { CartService } from 'src/app/service/cart.service';

@Component({
  selector: 'app-thankyou',
  templateUrl: './thankyou.component.html',
  styleUrls: ['./thankyou.component.scss']
})
export class ThankyouComponent implements OnInit {
  public productlist:any;

  constructor(private cartService : CartService) { }

  ngOnInit(): void {
    this.cartService.getProducts()
    .subscribe(res=>{
      this.productlist = res;
      this.productlist.forEach((element: { id: number; }) => {
        this.cartService.removeCartItem(element.id)
        .subscribe(res => {      
          console.log(res);
          console.log("Removed From the Cart");
        }, error => {
         console.log("Something Went Wrong");
        }
        )
        
      });
    })
  }

}
