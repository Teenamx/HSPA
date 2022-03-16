import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Router } from '@angular/router';
import { UserForLogin } from 'src/app/model/user';
import { AlertifyService } from 'src/app/services/alertify.service';
import { AuthService } from 'src/app/services/auth.service';

@Component({
  selector: 'app-user-login',
  templateUrl: './user-login.component.html',
  styleUrls: ['./user-login.component.css']
})
export class UserLoginComponent implements OnInit {

  constructor(private authService:AuthService,private alertify:AlertifyService,private router:Router) { }

  ngOnInit(): void {
  }
  onLogin(loginForm:NgForm)
  {
    console.log(loginForm.value);

    // const token=this.authService.authUser(loginForm.value);
    this.authService.authUser(loginForm.value).subscribe(
      (response:UserForLogin)=>{
        const user=response;
        console.log(response);
        localStorage.setItem('token',user.token);
        localStorage.setItem('userName',user.userName);
        this.alertify.success("Login Successful");
        this.router.navigate(['/']);
      }
     /*  ,
      error=>{
       console.log(error);
       this.alertify.error(error.error);
      } */

    )

    /*  if(token){
      localStorage.setItem('token',token.userName)
      this.alertify.success("Login Successful");
      this.router.navigate(['/']);
     }


       else
       this.alertify.error("Username or password wrong"); */
  }

}
