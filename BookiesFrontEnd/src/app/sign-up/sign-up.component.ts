import { Component } from '@angular/core';
import { Router } from "@angular/router";

@Component({
  selector: 'app-sign-up',
  templateUrl: './sign-up.component.html',
  styleUrls: ['./sign-up.component.css']
})
export class SignUpComponent {

  constructor(private router:Router) {
  }

  passwordType1: string = 'password';
  passwordType2: string = 'password';
  passwordShown: boolean = false;

  Email:string="";
  Username:string="";
  Password1:string="";
  Password2:string="";

  ChangeVisibility1() {
    if(this.passwordShown){
      this.passwordShown=false;
      this.passwordType1='password';
    }else{
      this.passwordShown=true;
      this.passwordType1='text';
    }
  }
  ChangeVisibility2() {
    if(this.passwordShown){
      this.passwordShown=false;
      this.passwordType2='password';
    }else{
      this.passwordShown=true;
      this.passwordType2='text';
    }
  }

  OpenLogIn() {
    this.router.navigateByUrl("LogIn")
  }
}
