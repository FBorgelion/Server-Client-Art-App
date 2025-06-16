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

  addProduct(product: { title: string; description: string; price: number; stock: number; images: string;}): Observable<any> {
    return this.http.post(`https://localhost:7041/api/Product`, product);
  }

  updateProduct( id: number, product: {title: string;description: string;price: number;stock: number;images: string;}): Observable<void> {
    return this.http.put<void>(`https://localhost:7041/api/Product/${id}`, product);
  }

  uploadImage(file: File): Observable<{ url: string }> {
    const fd = new FormData();
    fd.append('file', file, file.name);
    return this.http.post<{ url: string }>(`https://localhost:7041/api/Upload/image`, fd);
  }

  addProductWithImage(formData: FormData): Observable<any> {
    return this.http.post(`${this.baseUrl}`, formData);
  }

  updateProductWithImage(id: number, formData: FormData): Observable<any> {
    return this.http.put(`${this.baseUrl}/${id}`, formData);
  }



}
