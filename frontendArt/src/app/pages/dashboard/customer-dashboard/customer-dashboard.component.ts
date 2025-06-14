import { Component, OnInit } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { CartComponent } from './cart/cart.component';
import { CommonModule } from '@angular/common';
import { CartService } from '../../../service/cart/cart.service';
import { CustomerService } from '../../../service/customer/customer.service';
import { OrdersComponent } from './orders/orders.component';

@Component({
  selector: 'app-customer-dashboard',
  standalone: true,
  imports: [CommonModule, FormsModule, CartComponent, OrdersComponent],
  templateUrl: './customer-dashboard.component.html',
  styleUrl: './customer-dashboard.component.css'
})
export class CustomerDashboardComponent implements OnInit {

  activeSection: 'cart' | 'profile' | 'orders' = 'cart';

  profile: any = {
    shippingAddress: '',
    paymentInfo: ''
  }

  private _backupProfile!: any;

  constructor( private customerService: CustomerService, private cartService: CartService ) { }

  ngOnInit() {
    this.loadProfile();
  }

  select(section: 'cart' | 'profile' | 'orders') {
    this.activeSection = section;
    if (section === 'profile') {
      this.backupProfile();
    }
  }

  private loadProfile() {
    this.customerService.getCustomer().subscribe(c => {
      this.profile = {
        shippingAddress: c.shippingAddress,
        paymentInfo: c.paymentInfo
      };
      this.backupProfile();
    });
  }

  private backupProfile() {
    this._backupProfile = {
      shippingAddress: this.profile.shippingAddress,
      paymentInfo: this.profile.paymentInfo
    };
  }

  saveProfile() {
    this.customerService.updateProfile(this.profile)
      .subscribe({
        next: () => {
          alert('Profile updated.');
          this.backupProfile();
        },
      });
  }

  cancelEdit() {
    this.profile = { ...this._backupProfile };
  }

}
