import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { HttpHeaders } from '@angular/common/http';

import { Observable } from 'rxjs';
import { User } from 'src/app/shared/models/user';

@Injectable()
export class UserHttpService {
  private loginUrl = "https://localhost:5001/home/login";
 
  private httpOptions = {
    headers: new HttpHeaders({
      'Content-Type':  'application/json'
    })
  };

  constructor(private http: HttpClient) { }

  login(user: User): Observable<any> {
    return this.http.post<User>(this.loginUrl, JSON.stringify(user), this.httpOptions);
  }
}