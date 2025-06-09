import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { RouterModule } from '@angular/router';
import { DeliveryOrdersComponent } from './delivery-orders/delivery-orders.component';

@Component({
  selector: 'app-delivery-partner-dashboard',
  standalone: true,
  imports: [CommonModule, RouterModule, DeliveryOrdersComponent],
  templateUrl: './delivery-partner-dashboard.component.html',
  styleUrl: './delivery-partner-dashboard.component.css'
})
export class DeliveryPartnerDashboardComponent {

}
