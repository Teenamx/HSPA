import { Component, Input, OnInit } from '@angular/core';
import { IPropertyBase } from 'src/app/model/IPropertyBase';

@Component({
  selector: 'app-product-data',
  templateUrl: './product-data.component.html',
  styleUrls: ['./product-data.component.css']
})
export class ProductDataComponent implements OnInit {
 /*  Property:any={
    "Id":1,
    "Type":"House",
    "Price":12000,
    "Name":"Birla"
  } */
  constructor() { }
@Input() property:IPropertyBase;
@Input() hideIcons:boolean;
  ngOnInit(): void {
  }

}
