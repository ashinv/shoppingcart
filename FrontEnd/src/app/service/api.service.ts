import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import {map} from 'rxjs/operators';
import { ProductModule } from '../model/product/product.module';
@Injectable({
  providedIn: 'root'
})
export class ApiService {

  constructor(private http : HttpClient) { }

  getProduct(){
    return this.http.get<ProductModule>("http://localhost:3000/products")
    .pipe(map((res:ProductModule)=>{
      return res;
    }))
  }
}
