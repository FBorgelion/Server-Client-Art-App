import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class CartService {

  constructor(private http: HttpClient) { }

  getCart(): Observable<any> {
    return this.http.get(`https://localhost:7041/api/Cart`);
  }

  addItem(ProductId: number, Quantity: number): Observable<void> {
    return this.http.post<void>(`https://localhost:7041/api/Cart`, { ProductId, Quantity });
  }

  removeItem(cartId: number): Observable<void> {
    return this.http.delete<void>(`https://localhost:7041/api/Cart/${cartId}`);
  }

  clearCart(): Observable<void> {
    return this.http.delete<void>(`https://localhost:7041/api/Cart/clear`);
  }

  checkout(): Observable<void> {
    return this.http.post<void>(`https://localhost:7041/api/Cart/checkout`, {});
  }

}
