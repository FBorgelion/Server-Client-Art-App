import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

export interface ReportRow { period: string; amount: number; }

@Injectable({
  providedIn: 'root'
})
export class OrderService {

  constructor(private httpClient: HttpClient) { }

  getArtisanOrders(): Observable<any> {
    return this.httpClient.get(`https://localhost:7041/api/Artisan/orders`);
  }

  updateStatus(orderId: number, status: string): Observable<void> {
    return this.httpClient.put<void>(`https://localhost:7041/api/Order/${orderId}/status`, { status });
  }

  getAssignedOrders(): Observable<any[]> {
    return this.httpClient.get<any[]>(`https://localhost:7041/api/Order/assigned`);
  }

  updateStatusDp(orderId: number, status: string): Observable<void> {
    return this.httpClient.put<void>(`https://localhost:7041/api/Order/${orderId}/dp/status`, { status });
  }

  getCustomerOrders(): Observable<any> {
    return this.httpClient.get(`https://localhost:7041/api/Order/customers/orders`);
  }

  getRevenue(period: 'week' | 'month' | 'year'): Observable<any[]> {
    return this.httpClient.get<any[]>(`https://localhost:7041/api/Order/revenue?period=${period}`);
  }

}


