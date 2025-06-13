import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class CustomerService {

  constructor(private http: HttpClient) { }

  getCustomers(): Observable<any> {
    return this.http.get(`https://localhost:7041/api/Customer`);
  }

  deleteCustomer(id: number): Observable<any> {
    return this.http.delete(`https://localhost:7041/api/Customer/${id}`);
  }

}

