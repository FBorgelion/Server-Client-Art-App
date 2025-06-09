// src/app/pages/dashboard/delivery-partner-dashboard/delivery-orders.component.ts

import { Component, OnInit } from '@angular/core';
import { OrderService } from '../../../../service/order/order.service';
import { catchError, of } from 'rxjs';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-delivery-orders',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './delivery-orders.component.html',
  styleUrls: ['./delivery-orders.component.css']
})
export class DeliveryOrdersComponent implements OnInit {
  orders: any;
  loading = true;

  constructor(private orderService: OrderService) { }

  ngOnInit(): void {
    this.orderService.getAssignedOrders()
      .pipe(catchError(err => { console.error(err); return of([]); }))
      .subscribe(data => {
        this.orders = data;
        this.loading = false;
      });
  }

  /** Concatène les titres et quantités comme "Tasse × 2, Mug × 1" */
  getProductTitles(order: { items: { productTitle: string; quantity: number }[] }): string {
    return order.items
      .map(i => `${i.productTitle} × ${i.quantity}`)
      .join(', ');
  }

  updateStatus(orderId: number, newStatus: 'InTransit' | 'Delivered'): void {
    this.orderService.updateStatusDp(orderId, newStatus)
      .subscribe({
        next: () => {
          const o = this.orders.find((x: { orderId: number; }) => x.orderId === orderId);
          if (o) { o.status = newStatus; }
        },
        error: err => {
          console.error('Status change failed', err);
          alert('Impossible de mettre à jour le statut.');
        }
      });
  }
}
