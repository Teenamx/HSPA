import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { HousingService } from 'src/app/housing.service';

import { IPropertyBase } from 'src/app/model/IpropertyBase';



@Component({
  selector: 'app-productlist',
  templateUrl: './productlist.component.html',
  styleUrls: ['./productlist.component.css']
})
export class ProductlistComponent implements OnInit {

  Properties:Array<IPropertyBase>;
  constructor(private route:ActivatedRoute ,private housingService:HousingService) { }
  sellRent=1;

  ngOnInit(): void {
    if(this.route.snapshot.url.toString())
    {
     this.sellRent=2;
    }
    this.housingService.getAllProperties(this.sellRent).subscribe(
      data=>
      {
        this.Properties=data;
       // const newProperty=JSON.parse(localStorage.getItem('newProp'));
      /*   if(newProperty.SellRent===this.sellRent)
        {
          this.Properties=[newProperty,...this.Properties]
        } */
        console.log(data)
        console.log(this.route.snapshot.url.toString());
      },
      error=>{
        console.log(error);
      }

    )
  }

}
