import { HttpErrorResponse, HttpHandler, HttpInterceptor, HttpRequest } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { throwError } from "rxjs";


import { catchError } from "rxjs/operators";
import { AlertifyService } from 'src/app/services/alertify.service';
@Injectable({
  providedIn:'root'
})

export class HttperrorInterceptorService implements HttpInterceptor {
  constructor(private alertify:AlertifyService){

  }
intercept(req: HttpRequest<any>, next: HttpHandler) {
  console.log("Request Started");
    return next.handle(req)
    .pipe(catchError((error:HttpErrorResponse)=>
    {
      console.log("hi");
      console.log(error);
      console.log(error.error);
      console.log(ErrorEvent);
      const errorMessage=this.setError(error);

      this.alertify.error(errorMessage);
      return throwError(errorMessage);
     } )


    )}

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



