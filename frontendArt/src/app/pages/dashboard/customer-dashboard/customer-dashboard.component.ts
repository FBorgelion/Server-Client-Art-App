import { Component, OnInit } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { CartComponent } from './cart/cart.component';
import { CommonModule } from '@angular/common';
import { CartService } from '../../../service/cart/cart.service';
import { CustomerService } from '../../../service/customer/customer.service';
import { OrdersComponent } from './orders/orders.component';
import { InquiryService } from '../../../service/inquiries/inquiry.service';

@Component({
  selector: 'app-customer-dashboard',
  standalone: true,
  imports: [CommonModule, FormsModule, CartComponent, OrdersComponent],
  templateUrl: './customer-dashboard.component.html',
  styleUrl: './customer-dashboard.component.css'
})
export class CustomerDashboardComponent implements OnInit {

  activeSection: 'cart' | 'profile' | 'inquiries' | 'orders'  = 'cart';

  inquiries: any[] = [];
  loadingInquiries = false;
  errorInquiries = '';

  profile: any = {
    shippingAddress: '',
    paymentInfo: ''
  }

  private _backupProfile!: any;

  constructor(private customerService: CustomerService, private cartService: CartService, private inquirySvc: InquiryService) { }

  ngOnInit() {
    this.loadProfile();
  }

  select(section: 'cart' | 'profile' | 'inquiries' | 'orders' ) {
    this.activeSection = section;
    if (section === 'profile') {
      this.backupProfile();
    }
    if (section === 'inquiries') {
      this.loadInquiries();
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

  private loadInquiries() {
    this.loadingInquiries = true;
    this.errorInquiries = '';
    this.inquirySvc.getByCustomer().subscribe({
      next: (list: any[]) => {
        this.inquiries = list;
        this.loadingInquiries = false;
      },
      error: (err: any) => {
        console.error(err);
        this.errorInquiries = 'Cannot load your inquiries.';
        this.loadingInquiries = false;
      }
    });
  }

  onDeleteInquiry(id: number) {
    if (!confirm('Do you really want to delete this request?')) return;
    this.inquirySvc.deleteInquiry(id).subscribe({
      next: () => this.loadInquiries(),
      error: err => {
        console.error(err);
        alert('Unable to delete the inquiry.');
      }
    });
  }

}
