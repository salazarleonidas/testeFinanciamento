import { Injectable } from '@angular/core';
import {
  HttpEvent, HttpInterceptor, HttpHandler, HttpRequest, HttpResponse, HttpErrorResponse
} from '@angular/common/http';

import { tap } from 'rxjs/operators';
import { Observable } from 'rxjs';
import { Router } from '@angular/router';
import { CookieService } from './cookie.service';

@Injectable()
export class AuthInterceptor implements HttpInterceptor {

  private cookieService : CookieService;
  constructor(private router: Router) {
    this.cookieService = new CookieService;
  }
  intercept(request: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
    let accessToken = this.cookieService.getCookie('token');
    if(accessToken)
    {
        request = request.clone({
        setHeaders: {
            Authorization: `Bearer ${accessToken}`
        }
        });
    }

    return next.handle(request).pipe(tap((event: HttpEvent<any>) => {
      if (event instanceof HttpResponse) {
      }
    }, (err: any) => {
      if (err instanceof HttpErrorResponse) {
        if (err.status === 401) {
            this.router.navigate(['home']);
        }
      }
    }));
  }
}