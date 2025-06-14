import { Component, OnInit } from '@angular/core';
import { OrderService } from '../../../../service/order/order.service';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-artisan-orders',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './artisan-orders.component.html',
  styleUrl: './artisan-orders.component.css'
})
export class ArtisanOrdersComponent implements OnInit {

  orders: any;
  loading = true;

  constructor(private orderService: OrderService) { }

  ngOnInit(): void {
    this.orderService.getArtisanOrders().subscribe(data => this.orders = data);
    this.loading = false;
  }

  getProductTitles(order: any): string {
    return order.items
      .map((i: { productTitle: any; }) => i.productTitle)
      .join(', ');
  }

  toggleStatus(o: any) {
    const next = o.status === 'InProduction' ? 'Shipped' : 'InProduction';
    this.orderService.updateStatus(o.orderId, next)
      .subscribe({
        next: () => o.status = next,
        error: err => {
          console.error('Status change failed', err);
          alert('Impossible de changer le statut.');
        }
      });
  }

}
