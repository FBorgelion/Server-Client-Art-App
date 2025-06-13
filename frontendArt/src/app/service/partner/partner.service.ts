import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class PartnerService {

  constructor(private http: HttpClient) { }

  getPartners(): Observable<any> {
    return this.http.get(`https://localhost:7041/api/DeliveryPartner`);
  }

  deletePartner(id: number): Observable<any> {
   return this.http.delete(`https://localhost:7041/api/DeliveryPartner/${id}`);
  }

}
