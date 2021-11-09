
import { Component, OnInit } from '@angular/core';
import { interval, Subscription } from 'rxjs';
import { CartService } from 'src/app/service/cart.service';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.scss']
})
export class HeaderComponent implements OnInit {

  public updateSubscription: Subscription | undefined;
  public totalItem : number = 0;
  public searchTerm !: string;
  public flag:number=0;
  constructor(private cartService : CartService) { }

  ngOnInit():void {
    this.updateSubscription = interval(1000).subscribe(
      (val) => { this.fetchcart()});
 
  }
  private fetchcart()
  {
    this.cartService.getProducts()
    .subscribe(res=>{
       this.totalItem = res.length;
    })
  }
  search(event:any){
    this.searchTerm = (event.target as HTMLInputElement).value;
    console.log(this.searchTerm);
    this.cartService.search.next(this.searchTerm);
  }
  async login()
  {
    await new Promise<void>(done => setTimeout(() => done(), 8000));
    this.flag=1;
  }
  logout()
  {
    this.flag=0;
  }
}
