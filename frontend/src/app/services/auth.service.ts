import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment';
import { UserForLogin,UserForRegistration} from '../model/user';
@Injectable({
  providedIn: 'root'
})
export class AuthService {

  baseurl=environment.baseUrl;
  constructor(private http:HttpClient) { }
  authUser(user:UserForLogin)
  {
    return this.http.post(this.baseurl+'/account/login',user);
  /*   let userArray=[];
    if(localStorage.getItem('Users'))
    {
      userArray=JSON.parse(localStorage.getItem('Users'));
      console.log(userArray);
    }
    return userArray.find(p=>p.userName===user.userName && p.password===user.password); */
  }
  registerUser(user:UserForRegistration)
  {
    return this.http.post(this.baseurl+'/account/register',user)
  }
}
