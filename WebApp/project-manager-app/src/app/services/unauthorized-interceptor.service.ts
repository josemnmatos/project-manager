import {
  HttpInterceptor,
  HttpRequest,
  HttpHandler,
  HttpEvent,
  HttpErrorResponse,
} from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { Observable, catchError, throwError } from 'rxjs';

@Injectable()
export class UnauthorizedInterceptorService implements HttpInterceptor {
  constructor(private router: Router) {}

  intercept(request: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
   return next.handle(request).pipe(catchError(err => {
       if ([401, 403].includes(err.status)) {
           // redirect to the unauthorized page
             this.router.navigate(['/unauthorized']);
       }

       const error = err.error?.message || err.statusText;
       console.error(err);
       return throwError(() => error);
   }))
}
}
