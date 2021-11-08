import { CartsModule } from './../model/carts/carts.module';


import { HttpClientModule } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable } from 'rxjs';
import { HttpClient, HttpHeaders } from '@angular/common/http';




@Injectable({
  providedIn: 'root'
})
export class CartService {

  public cartItemList : any;

  public grandTotal:number=0;
  public search = new BehaviorSubject<string>("");
 
  constructor(private httpclient:HttpClient) { }
  getProducts():Observable<any>{
     return this.httpclient.get<Array<CartsModule>>("http://localhost:64413/api/Carts");
  }
  addtoCart(product : CartsModule){
   
   
    return this.httpclient.post<CartsModule>("http://localhost:64413/api/Carts", product);

  }
  getTotalPrice():number{
this.grandTotal=0;
    this.getProducts()
    .subscribe(res=>{
      this.cartItemList = res;
      this.cartItemList.forEach((a:CartsModule) => {
        this.grandTotal+=a.total;
        });
      });    
    console.log(this.grandTotal);
    return this.grandTotal;
  }
  removeCartItem(id:number):Observable<CartsModule>{
    return this.httpclient.delete<CartsModule>("http://localhost:64413/api/Carts/"+id);
    
  }
  updateCart(item:CartsModule):Observable<any>{
    return this.httpclient.put<CartsModule>("http://localhost:64413/api/Carts/"+item.id,item);
  }

}
