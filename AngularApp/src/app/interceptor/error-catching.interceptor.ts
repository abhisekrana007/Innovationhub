import { Injectable } from '@angular/core';
import {
  HttpRequest,
  HttpHandler,
  HttpEvent,
  HttpInterceptor,
  HttpErrorResponse
} from '@angular/common/http';
import { Observable, catchError, map, throwError } from 'rxjs';
import { LoginService } from '../services/login.service';

@Injectable()
export class ErrorCatchingInterceptor 
implements HttpInterceptor {
 
  errorMsg : string="";
  constructor(private _loginservice : LoginService) {}

  intercept(request: HttpRequest<unknown>,
     next: HttpHandler): Observable<HttpEvent<unknown>> {
      const token = this._loginservice.getBearerToken();

      if (token) {
        // If we have a token, we set it to the header
        request = request.clone({
            setHeaders: {Authorization: `Bearer ${token}`}
        });
      } 
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

        case 401: {

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


