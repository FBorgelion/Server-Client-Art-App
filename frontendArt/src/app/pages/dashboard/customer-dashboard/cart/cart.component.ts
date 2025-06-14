import { CommonModule } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { CartService } from '../../../../service/cart/cart.service';
import { Router, RouterModule } from '@angular/router';

@Component({
  selector: 'app-cart',
  standalone: true,
  imports: [CommonModule, RouterModule],
  templateUrl: './cart.component.html',
  styleUrl: './cart.component.css'
})
export class CartComponent implements OnInit {

  cart: any[] = [];
  loading = true;
  checkingOut = false;

  constructor(private cartSvc: CartService, private route: Router) { }

  ngOnInit() {
    this.loadCart();
  }

  loadCart() {
    this.loading = true;
    this.cartSvc.getCart().subscribe({
      next: items => {
        this.cart = items;
        this.loading = false;
      },
      error: err => {
        console.error('Load cart failed', err);
        this.loading = false;
      }
    });
  }

  remove(item: any) {
    this.cartSvc.removeItem(item.cartItemId)
      .subscribe(() => this.loadCart());
  }

  clear() {
    if (!confirm('Clear cart ?')) return;
    this.cartSvc.clearCart().subscribe({
      next: () => this.loadCart(),
      error: err => {
        console.error('Clear cart failed', err);
        alert('Clear cart failed.');
      }
    });
  }

  checkout() {
    if (this.cart.length === 0) {
      alert('Your cart is empty.');
      return;
    }
    if (!confirm('Submit order ?')) return;

    this.checkingOut = true;
    this.cartSvc.checkout().subscribe({
      next: () => {
        alert('Order send !');
        this.checkingOut = false;
        this.loadCart();
        // si vous voulez rediriger vers la page des commandes :
        // this.router.navigate(['/dashboard/customer/orders']);
      },
      error: err => {
        console.error('Checkout failed', err);
        alert('Cannot validate order.');
        this.checkingOut = false;
      }
    });
  }

}
