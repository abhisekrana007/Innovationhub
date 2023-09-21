import { Injectable } from '@angular/core';
import {
  HttpRequest,
  HttpHandler,
  HttpEvent,
  HttpInterceptor,
  HttpErrorResponse
} from '@angular/common/http';
import { Observable, catchError, map, throwError } from 'rxjs';

@Injectable()
export class ErrorCatchingInterceptor 
implements HttpInterceptor {
 
  errorMsg : string="";
  constructor() {}

  intercept(request: HttpRequest<unknown>,
     next: HttpHandler): Observable<HttpEvent<unknown>> {
    console.log("Passed through the interceptor in request");
    return next.handle(request)
    .pipe(
      map(res => {
         console.log("Passed through the interceptor in response");
         return res
      }),

      catchError(err => {
      // client side errors
        if (err.error instanceof ErrorEvent) {
  
            this.errorMsg = `Error: ${err.error.message}`;
  
        } 
        else {
  
            this.errorMsg = this.getServerErrorMessage(err);
  // alert(this.errorMsg)
        }
  
        return throwError(this.errorMsg);
  
    })
  
  );
   
  }
  
  private getServerErrorMessage(error: HttpErrorResponse)
  : string {
  
    // console.log("RRRRRR " + error.status)
    switch (error.status) {
  
        case 404: {
  
          // console.log("aaaaaaaaaaaaaa");
            return `Not Found: ${error.message}`;
  
        }
  
        case 403: {
  
            return `Access Denied: ${error.message}`;
  
        }
  
        case 500: {
  
            return `Internal Server Error: ${error.error}`;
  
        }
  
        default: {
  
            return `Unknown Server Error: ${error.message}`;
  
        }
  
    }
    
  }
  

  }


