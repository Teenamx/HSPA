import { HttpErrorResponse, HttpHandler, HttpInterceptor, HttpRequest } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable, of, throwError } from "rxjs";


import { catchError, concatMap, retryWhen } from "rxjs/operators";
import { AlertifyService } from 'src/app/services/alertify.service';
import { ErrorCode } from "../Enums/enums";
@Injectable({
  providedIn:'root'
})

export class HttperrorInterceptorService implements HttpInterceptor {
  constructor(private alertify:AlertifyService){

  }
intercept(req: HttpRequest<any>, next: HttpHandler) {
  console.log("Request Started");
    return next.handle(req)
    .pipe(retryWhen(error => this.retryRequest(error,10))
  ,

      catchError((error:HttpErrorResponse)=>
    {

      const errorMessage=this.setError(error);

      this.alertify.error(errorMessage);
      return throwError(errorMessage);
     } ))


    }
    retryRequest(error: Observable<unknown>,retryCount:number) :Observable<unknown>
    {
     return  error.pipe(
        concatMap((checkErr:HttpErrorResponse , count:number)=>{

          if(count <= retryCount)
          {
          switch(checkErr.status)
          {
            case ErrorCode.serverDown:
            return of(checkErr);
          }
        }
          return throwError(checkErr);
        })
     )
    }
    setError(error:HttpErrorResponse):string{
      let errorMessage='unknown error occured';
      if(error.error instanceof ErrorEvent)
      {
        //client side error
        errorMessage=error.error.message;
      }
      else{
        //server side error
        if(error.status!=0){
          errorMessage=error.error.errorMessage;
        }
      }
        return errorMessage;


    }
}



