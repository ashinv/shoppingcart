import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';

@Component({
  selector: 'app-checkout',
  templateUrl: './checkout.component.html',
  styleUrls: ['./checkout.component.scss']
})
export class CheckoutComponent implements OnInit {
  public AddressForm!:FormGroup;
  constructor(private formbuilder:FormBuilder) { }

  ngOnInit(): void {
    this.AddressForm=this.formbuilder.group({
      firstName:[''], 
      lastName:[''],
      address:[''],
      country:[''],
      state:[''],
      zip:[''],
      PhoneNumber:['']
  })

}

save(){
  console.log(this.AddressForm.value);
  this.AddressForm.reset();
}

  }
