import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { jwtDecode } from 'jwt-decode';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class AuthenticationService {

  constructor(private http: HttpClient) { }

  Login(username: string, password: string): Observable<any> {
    return this.http.post(`https://localhost:7041/api/Authentication/LogIn?username=${username}&password=${password}`, null);
  }

  register(username: string, email: string, password: string, role: string): Observable<any> {
    const body = { username, email, password, role };
    return this.http.post(`https://localhost:7041/api/Authentication/Register?password=${password}&username=${username}&email=${email}&role=${role}`, body);
  }

  isAuthenticated(): boolean {
    const token = sessionStorage.getItem('jwt');
    return token != null;
  }

  logout(): void {
    sessionStorage.removeItem('jwt');
    sessionStorage.removeItem('roles');  
  }

  getUserRoles(): string {
    const token = sessionStorage.getItem('jwt');
    if (!token) {
      return '';  
    }

    try {
      const decodedToken: any = jwtDecode(token);

      if (this.isTokenExpired(decodedToken)) {
        console.warn('Token expired');
      }

      return decodedToken['http://schemas.microsoft.com/ws/2008/06/identity/claims/role'] || '';
    } catch (error) {
      console.error('Error decoding token', error);
      return '';  
    }
  }

  private isTokenExpired(decodedToken: any): boolean {
    const expirationDate = new Date(decodedToken.exp * 1000);  
    return expirationDate < new Date();
  }

}
