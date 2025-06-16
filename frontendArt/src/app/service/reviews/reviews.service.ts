import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ReviewsService {

  constructor(private http: HttpClient) { }

  getReviewsByProduct(id: number): Observable<any> {
    return this.http.get(`https://localhost:7041/api/Review/product/${id}`);
  }

  getReviewsByCustomer(id: number): Observable<any> {
    return this.http.get(`https://localhost:7041/api/Review/customer/${id}`);
  }

  deleteReview(id: number): Observable<any> {
    return this.http.delete(`https://localhost:7041/api/Review/${id}`);
  }
  addReview(payload: any): Observable<any> {
    return this.http.post('https://localhost:7041/api/Review', payload );
  }

}
