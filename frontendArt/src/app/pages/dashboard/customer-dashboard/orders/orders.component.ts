import { CommonModule } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { RouterModule } from '@angular/router';
import { OrderService } from '../../../../service/order/order.service';

@Component({
  selector: 'app-orders',
  standalone: true,
  imports: [CommonModule, RouterModule],
  templateUrl: './orders.component.html',
  styleUrl: './orders.component.css'
})
export class OrdersComponent implements OnInit {

  constructor(private orderSvc: OrderService) { }

  orders: any[] = [];
  loading = true;
  error = '';

  ngOnInit(): void {
    this.loadOrders();
  }

  loadOrders() {
    this.loading = true;
    this.orderSvc.getCustomerOrders().subscribe({
      next: data => {
        this.orders = data;
        this.loading = false;
      },
      error: err => {
        console.error(err);
        this.error = 'Cannot load orders.';
        this.loading = false;
      }
    });
  }

}
