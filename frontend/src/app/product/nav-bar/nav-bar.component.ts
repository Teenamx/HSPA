import { Component, OnInit } from '@angular/core';

import { Router } from '@angular/router';
import { AlertifyService } from 'src/app/services/alertify.service';

@Component({
  selector: 'nav-bar',
  templateUrl: './nav-bar.component.html',
  styleUrls: ['./nav-bar.component.css']
})
export class NavBarComponent implements OnInit {

  loggedInUser:string;
  constructor(private router:Router,private alertify:AlertifyService) { }

  ngOnInit(): void {
  }

  loggedIn()
  {

    this.loggedInUser= localStorage.getItem('token');
    return this.loggedInUser;
  }
  onLogOut()
  {
    localStorage.removeItem('token');
    this.alertify.success("You are logged out")
  }

}
