import { Component, OnInit } from '@angular/core';
import { ProductService } from '../../service/product.service';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { RouterModule } from '@angular/router';
import { AuthenticationService } from '../../service/authentication/authentication.service';
import { CartService } from '../../service/cart/cart.service';

@Component({
  selector: 'app-products',
  standalone: true,
  imports: [CommonModule, RouterModule, FormsModule],
  templateUrl: './products.component.html',
  styleUrl: './products.component.css'
})
export class ProductsComponent implements OnInit {

  products: any;
  loading = true;
  error = '';

  constructor(private svc: ProductService, private authSvc: AuthenticationService, private cartSvc: CartService) { }

  ngOnInit(): void {
    this.svc.getProducts().subscribe({
      next: ps => { this.products = ps; this.loading = false; },
      error: err => { this.error = 'Not able to load products.'; this.loading = false; }
    });
  };

  isCustomer(): boolean {
    return this.authSvc.isAuthenticated() && this.authSvc.hasRole('Customer');
  }

  addToCart(productId: number) {
    this.cartSvc.addItem(productId, 1).subscribe({
      next: () => alert('Product added to cart !'),
      error: () => alert('Cannot add to cart.')
    });
  }

}
