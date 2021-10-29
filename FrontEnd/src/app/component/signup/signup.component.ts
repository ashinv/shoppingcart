import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import{FormGroup,FormBuilder} from '@angular/forms'
import { Router } from '@angular/router';
@Component({
  selector: 'app-signup',
  templateUrl: './signup.component.html',
  styleUrls: ['./signup.component.scss']
})
export class SignupComponent implements OnInit {


  emailPattern = "^[a-z0-9._%+-]+@[a-z0-9.-]+\.[a-z]{2,4}$";
  public signupForm!:FormGroup;
  constructor(private formbuilder:FormBuilder,private http:HttpClient,private router:Router) { }

  ngOnInit(): void {
    this.signupForm=this.formbuilder.group({
      Fullname:[''], 
      Mobilephone:[''],
      Email:[''],
      Password:['']
    })

  }
signUp(){
  this.http.post<any>("http://localhost:64413/api/CustomerTables",this.signupForm.value)
  .subscribe(res=>{
    alert("SignUp Successfull");
    this.signupForm.reset();
    this.router.navigate(['login']);
  },err=>{
    alert("Something went wrong");
  })
}
}
