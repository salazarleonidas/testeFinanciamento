import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { HttpHeaders } from '@angular/common/http';

import { Observable } from 'rxjs';
import { CookieService } from '../../shared/helpers/cookie.service';
import { Financiamento } from '../../shared/models/financiamento';

@Injectable()
export class FinanciamentoHttpService {
  private requistarUrl = "https://localhost:5001/financiamento";
 
  private cookieService: CookieService;

  constructor(private http: HttpClient) {
    this.cookieService = new CookieService;
   }

  requisitar(financiamento: Financiamento): Observable<Financiamento> {
    var token = this.cookieService.getCookie('token');
    var httpOptions = {
      headers: new HttpHeaders({
        'Content-Type':  'application/json', 
        // 'Authorization': 'bearer ' + token
      })
    };

    console.log(httpOptions)

    return this.http.post<Financiamento>(this.requistarUrl, JSON.stringify(financiamento), httpOptions);
  }
}