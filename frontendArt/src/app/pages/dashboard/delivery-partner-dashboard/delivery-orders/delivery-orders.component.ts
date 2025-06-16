import { Component, OnInit } from '@angular/core';
import { OrderService } from '../../../../service/order/order.service';
import { catchError, of } from 'rxjs';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-delivery-orders',
  standalone: true,
  imports: [CommonModule, FormsModule],  
  templateUrl: './delivery-orders.component.html',
  styleUrls: ['./delivery-orders.component.css']
})
export class DeliveryOrdersComponent implements OnInit {
  loading = true;
  orders: any[] = [];
  filteredOrders: any[] = [];
  statuses = [
    { label: 'All', value: '' },
    { label: 'Taken/PickedUp', value: 'PickedUp' },
    { label: 'In Production', value: 'InProduction' },
    { label: 'In Transit', value: 'InTransit' },
    { label: 'Shipped', value: 'Shipped' },
    { label: 'Delivered', value: 'Delivered' },
  ];
  selectedStatus = '';

  constructor(private orderService: OrderService) { }

  ngOnInit(): void {
    this.orderService.getAssignedOrders()
      .pipe(catchError(err => { console.error(err); return of([]); }))
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
    this.filteredOrders = this.selectedStatus
      ? this.orders.filter(o => o.status === this.selectedStatus)
      : this.orders.slice();  // copy all if no filter
  }

  updateStatus(orderId: number, newStatus: 'Shipped' | 'InTransit' | 'Delivered' | 'InProduction'): void {
    this.orderService.updateStatusDp(orderId, newStatus).subscribe({
      next: () => {
        const o = this.orders.find(x => x.orderId === orderId);
        if (o) {
          o.status = newStatus;
          this.applyFilter();   // re‐apply filter in case the item no longer matches
        }
      },
      error: err => {
        console.error('Status change failed', err);
        alert('Cannot update status.');
      }
    });
  }
}
