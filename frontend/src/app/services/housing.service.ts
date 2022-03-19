import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import {map} from 'rxjs/operators'
import { environment } from 'src/environments/environment';
import { IPropertyBase } from '../model/IPropertyBase';
import { Property } from '../model/property';
// import { IPropertyBase } from './model/IpropertyBase';
// import { Property } from './model/property';



@Injectable({
  providedIn: 'root'
})
export class HousingService {

  baseurl=environment.baseUrl;
  constructor(private http:HttpClient) { }

 getAllCities():Observable<string[]>
 {
   return this.http.get<string[]>('http://localhost:18633/api/city');
 }

  getProperty(id:number)
  {

    return this.http.get<Property>(this.baseurl+'/property/detail/'+id.toString());
    /* return this.getAllProperties(1).pipe(
      map(propertiesArray=>{
         return propertiesArray.find(p=>p.id===id);
      })
    ); */
  }

  getAllProperties(sellRent?:number):Observable<Property[]>
  {

    return this.http.get<Property[]>(this.baseurl+'/property/list/'+sellRent.toString());
   /*  return this.http.get('data/properties.json').pipe(
      map(data=>{
         const propertiesArray:Array<Property>=[];
         const localProperties=JSON.parse(localStorage.getItem('newProp'));
          if(localProperties)
          {
            for(const id in localProperties)
            {
              if(sellRent)
              {
              if(localProperties.hasOwnProperty(id) && localProperties[id].SellRent==sellRent)
              {
                propertiesArray.push(localProperties[id]);
              }
            }
            else
            {
              propertiesArray.push(localProperties[id]);
            }
            }
          }
         for(const id in data)
         {
           if(sellRent)
           {
           if(data.hasOwnProperty(id) && data[id].SellRent==sellRent)
           {
             propertiesArray.push(data[id]);
           }
          }
          else
          {
            propertiesArray.push(data[id]);
          }
         }
         return propertiesArray;
      })
    );
 */
  }
  addProperty(property:Property)
  {
    let newProp=[property];
    if(localStorage.getItem('newProp'))
    {
      newProp=[property,...JSON.parse(localStorage.getItem('newProp'))];
    }
    localStorage.setItem('newProp',JSON.stringify(newProp));
  }
  newPropID()
  {
    if(localStorage.getItem('PID'))
    {
      localStorage.setItem('PID',String(+localStorage.getItem('PID')+1));
      return +localStorage.getItem('PID');
    }
    else
    {
      localStorage.setItem('PID','101');
      return 101;
    }
  }

  getPropertyAge(dateOfEstablishment:Date):string
  {
       const today = new Date();
        const estDate = new Date(dateOfEstablishment);

        let age = today.getFullYear() - estDate.getFullYear();

        const m = today.getMonth() - estDate.getMonth();

        console.log(today.getDate() < estDate.getDate());
        // Current month smaller than establishment month or
        // Same month but current date smaller than establishment date
        if (m < 0 || (m === 0 && today.getDate() < estDate.getDate())) {
            age --;
        }

        // Establshment date is future date
        if(today < estDate) {
            return '0';
        }

        // Age is less than a year
        if(age === 0) {
            return 'Less than a year';
        }

        return age.toString();
  }

}
