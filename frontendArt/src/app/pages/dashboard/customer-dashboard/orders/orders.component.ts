import { CommonModule } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { RouterModule } from '@angular/router';
import { OrderService } from '../../../../service/order/order.service';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-orders',
  standalone: true,
  imports: [CommonModule, RouterModule, FormsModule],
  templateUrl: './orders.component.html',
  styleUrl: './orders.component.css'
})
export class OrdersComponent implements OnInit {

  orders: any[] = [];
  filteredOrders: any[] = [];
  loading = true;
  error = '';

  // 1. Liste des statuts pour le filtre
  statuses = [
    { label: 'All', value: '' },
    { label: 'In production', value: 'InProduction' },
    { label: 'Shipped', value: 'Shipped' },
    { label: 'In Transit', value: 'InTransit' },
    { label: 'Delivered', value: 'Delivered' },
  ];
  selectedStatus = '';

  constructor(private orderSvc: OrderService) { }

  ngOnInit(): void {
    this.loadOrders();
  }

  loadOrders() {
    this.loading = true;
    this.orderSvc.getCustomerOrders().subscribe({
      next: data => {
        this.orders = data;
        this.applyFilter();
        this.loading = false;
      },
      error: err => {
        console.error(err);
        this.error = 'Cannot load orders.';
        this.loading = false;
      }
    });
  }

  /** Applique le filtre selon selectedStatus */
  applyFilter() {
    if (!this.selectedStatus) {
      this.filteredOrders = this.orders;
    } else {
      this.filteredOrders = this.orders
        .filter(o => o.status === this.selectedStatus);
    }
  }

  /** Déclenché lorsque la sélection du filtre change */
  onStatusChange(status: string) {
    this.selectedStatus = status;
    this.applyFilter();
  }
}
