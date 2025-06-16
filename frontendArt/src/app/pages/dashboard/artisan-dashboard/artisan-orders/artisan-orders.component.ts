import { Component, OnInit } from '@angular/core';
import { OrderService } from '../../../../service/order/order.service';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { catchError, of } from 'rxjs';

@Component({
  selector: 'app-artisan-orders',
  standalone: true,
  imports: [CommonModule, FormsModule],  // ← add FormsModule
  templateUrl: './artisan-orders.component.html',
  styleUrls: ['./artisan-orders.component.css']
})
export class ArtisanOrdersComponent implements OnInit {
  orders: any[] = [];
  filteredOrders: any[] = [];
  loading = true;

  statuses = [
    { label: 'All', value: '' },
    { label: 'In Production', value: 'InProduction' },
    { label: 'Shipped', value: 'Shipped' },
    { label: 'InTransit', value: 'InTransit' },
    { label: 'Taken', value: 'Taken' },
    { label: 'Delivered', value: 'Delivered' }
  ];
  selectedStatus = '';

  constructor(private orderService: OrderService) { }

  ngOnInit(): void {
    this.orderService.getArtisanOrders()
      .pipe(catchError(_ => of([])))
      .subscribe(data => {
        this.orders = data;
        this.applyFilter();
        this.loading = false;
      });
  }

  onStatusChange(status: string) {
    this.selectedStatus = status;
    this.applyFilter();
  }

  private applyFilter() {
    if (!this.selectedStatus) {
      this.filteredOrders = [...this.orders];
    } else {
      this.filteredOrders = this.orders.filter(o => o.status === this.selectedStatus);
    }
  }

  toggleStatus(o: any) {
    const next = o.status === 'InProduction' ? 'Shipped' : 'InProduction';
    this.orderService.updateStatus(o.orderId, next)
      .subscribe({
        next: () => {
          o.status = next;
          this.applyFilter();  
        },
        error: err => {
          console.error('Status change failed', err);
          alert('Cannot change status.');
        }
      });
  }
}
