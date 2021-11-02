import { Component, OnInit } from '@angular/core';
import { CartsModule } from 'src/app/model/carts/carts.module';
import { ProductModule } from 'src/app/model/product/product.module';
import { ApiService } from 'src/app/service/api.service';
import { CartService } from 'src/app/service/cart.service';

@Component({
  selector: 'app-products',
  templateUrl: './products.component.html',
  styleUrls: ['./products.component.scss']
})
export class ProductsComponent implements OnInit {
item: ProductModule = new ProductModule();
  public productList : any ;
  public filterCategory : any
  searchKey:string ="";
  prod: CartsModule = new CartsModule();
  constructor(private api : ApiService, private cartService : CartService) { }

  ngOnInit(): void {
    this.api.getProduct()
    .subscribe(res=>{
      this.productList = res;
      this.filterCategory = res;
      this.productList.forEach((a:ProductModule) => {
        if(a.category ==="women's clothing" || a.category ==="men's clothing"){
          a.category ="fashion"
        }
        Object.assign(a,{quantity:1,total:a.price});
      });
      console.log(this.productList)
    });

    this.cartService.search.subscribe((val:any)=>{
      this.searchKey = val;
    })
  }
  addtocart(item:any){
    console.log(item);
    this.prod=item;
    console.log(this.prod);
    this.cartService.addtoCart(this.prod)
    .subscribe(res => {
    
      console.log(res);
      alert("Successfully Added to Cart");
      this.prod = new CartsModule();
    }, error => {
      alert("Something Went Wrong");
    }
    )
  }
  filter(category:string){
    this.filterCategory = this.productList
    .filter((a:any)=>{
      if(a.category == category || category==''){
        return a;
      }
    })
  }

}
