import { Component } from '@angular/core';
import { Router } from "@angular/router";

@Component({
  selector: 'app-log-in',
  templateUrl: './log-in.component.html',
  styleUrls: ['./log-in.component.css']
})
export class LogInComponent {

  constructor(private router:Router) {
  }

  passwordType1: string = 'password';
  passwordShown: boolean = false;

  Username:string="";
  Password:string="";

  ChangeVisibility() {
    if(this.passwordShown){
      this.passwordShown=false;
      this.passwordType1='password';
    }else{
      this.passwordShown=true;
      this.passwordType1='text';
    }
  }

  OpenSignUp() {
    this.router.navigateByUrl("SignUp")
  }
}
