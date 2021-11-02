import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import{FormGroup,FormBuilder} from '@angular/forms'
import { Router } from '@angular/router';
@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {
public loginForm!:FormGroup;
  constructor(private formbuilder:FormBuilder,private http:HttpClient,private router:Router) { }

  ngOnInit(): void {
    this.loginForm=this.formbuilder.group({
      Email:[''],
      Password:['']
    })
  }

  login(){
    this.http.get<any>("http://localhost:64413/api/Customers")
    .subscribe(res=>{
      const user =res.find((a:any)=>{
        return a.Email===this.loginForm.value.Email && a.Password===this.loginForm.value.Password
      });
      if(user){
        alert("Login Successfull");
        this.loginForm.reset();
        this.router.navigate(['products']);
      }
      else{
        alert("Login Failed");
  
      }
    },err=>{
      alert("Something went wrong");
    })

  }

}
