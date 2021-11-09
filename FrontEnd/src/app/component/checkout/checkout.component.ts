import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';

@Component({
  selector: 'app-checkout',
  templateUrl: './checkout.component.html',
  styleUrls: ['./checkout.component.scss']
})
export class CheckoutComponent implements OnInit {
  public AddressForm!:FormGroup;
  constructor(private formbuilder:FormBuilder,private http:HttpClient) { }

  ngOnInit(): void {
    this.AddressForm=this.formbuilder.group({
      firstName:[''], 
      lastName:[''],
      address1:[''],
      country:[''],
      state:[''],
      zip:[''],
      PhoneNumber:['']
  })

}

save(){
  console.log(this.AddressForm.value);
  this.http.post<any>("http://localhost:64413/api/Addresses",this.AddressForm.value)
  .subscribe(res=>{
    alert("Address saved Successfull");
    this.AddressForm.reset();
  },err=>{
    alert("Something went wrong");
  })
  this.AddressForm.reset();
}

  }
