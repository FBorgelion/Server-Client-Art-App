import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/internal/Observable';

@Injectable({
  providedIn: 'root'
})
export class ProductService {

  private baseUrl = `https://localhost:7041/api/Product`;

  constructor(private http: HttpClient) { }

  getProducts(): Observable<any> {
    return this.http.get(`https://localhost:7041/api/Product`);
  }

  getArtisanProducts(): Observable<any> {
    return this.http.get(`https://localhost:7041/api/Product/artisan`);
  }

  getProductByArtisan(artisanId: number): Observable<any> {
    return this.http.get(`https://localhost:7041/api/Product/${artisanId}/products`);
  }

  getProductById(id: number): Observable<any> {
    return this.http.get(`https://localhost:7041/api/Product/${id}`);
  }

  deleteProduct(id: number): Observable<void> {
    const url = `${this.baseUrl}/${id}`;
    return this.http.delete<void>(url);
  }

  updateProduct(id: number, product: any): Observable<void> {
    return this.http.put<void>(
      `https://localhost:7041/api/Product/${id}`,
      product
    );
  }



}
