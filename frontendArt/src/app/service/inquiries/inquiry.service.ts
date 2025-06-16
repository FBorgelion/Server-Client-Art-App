import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

export interface InquiryDTO {
  inquiryId: number;
  productId: number;
  customerId: number;
  productTitle: string;
  message: string;
  response: string;
  createdAt: string;
}

@Injectable({
  providedIn: 'root'
})
export class InquiryService {

  constructor(private http: HttpClient) { }

  getForArtisan(): Observable<any[]> {
    return this.http.get<any[]>(`https://localhost:7041/api/Inquiry/artisan`);
  }

  getByCustomer(): Observable<any[]> {
    return this.http.get<any[]>(`https://localhost:7041/api/Inquiry/customer`);
  }

  respond(inquiryId: number, response: string): Observable<any> {
    return this.http.put(
      `https://localhost:7041/api/Inquiry/${inquiryId}/response`,
      { response }
    );
  }

  deleteInquiry(inquiryId: number): Observable<void> {
    return this.http.delete<void>(`https://localhost:7041/api/Inquiry/${inquiryId}`);
  }

  addInquiry(payload: any): Observable<void> {
    return this.http.post<void>(`https://localhost:7041/api/Inquiry`, payload);
  }

}
