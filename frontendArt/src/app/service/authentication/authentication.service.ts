import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class AuthenticationService {

  constructor(private http: HttpClient) { }

  Login(username: string, password: string): Observable<any> {
    return this.http.post(`https://localhost:7041/api/Authentication/LogIn?username=${username}&password=${password}`, null);
  }

}
